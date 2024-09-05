// Upgrade NOTE: commented out 'float4x4 _Object2World', a built-in variable
// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/ShaderShinyCard"
{
    Properties
    {
        _MainTex ("Texture Principale", 2D) = "white" {}
        _ShineTex ("Texture de Brillance", 2D) = "black" {}
        _ShineIntensity ("Intensite de la Brillance", Range(0, 1)) = 0.5
        _ShineScale ("Echelle de la Brillance", Range(0.1, 5)) = 1.0
        _ShineSpeed ("Vitesse de la Brillance", Range(0.1, 10)) = 1.0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Overlay"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _ShineTex;
            float _ShineIntensity;
            float _ShineScale;
            float _ShineSpeed;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float2 shineOffset : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                // Calculer un offset fixe pour la brillance en diagonale
                float time = _Time.y * _ShineSpeed;
                float2 shineUVOffset = float2(0.5, 0.5) * _ShineScale * time;

                // Garder les coordonnées UV dans la plage [0, 1]
                shineUVOffset = frac(o.uv + shineUVOffset) - 0.5;

                o.shineOffset = v.uv + shineUVOffset;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Couleur de la texture principale de la carte
                fixed4 col = tex2D(_MainTex, i.uv);

                // Échantillonner la texture de brillance avec l'offset dynamique
                fixed4 shineColor = tex2D(_ShineTex, i.shineOffset);
                shineColor *= _ShineIntensity;

                // Mélanger la texture principale avec l'effet de brillance
                fixed4 finalColor = lerp(col, shineColor, shineColor.a);

                // Conserver l'alpha de la texture principale
                finalColor.a = col.a;

                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Transparent"
}
