Shader "Unlit/ShaderHolographicCard"
{
    Properties
    {
        _MainTex ("Texture Principale", 2D) = "white" {}
        _HoloIntensity ("Intensite de l'effet Holographique", Range(0, 1)) = 0.5
        _HoloScale ("Echelle de l'effet Holographique", Range(0.1, 5)) = 1.0
        _HoloSpeed ("Vitesse du changement Holographique", Range(0.1, 10)) = 1.0
        _Color1 ("Couleur Holo 1", Color) = (1, 0, 0, 1)
        _Color2 ("Couleur Holo 2", Color) = (0, 1, 0, 1)
        _Color3 ("Couleur Holo 3", Color) = (0, 0, 1, 1)
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
            float _HoloIntensity;
            float _HoloScale;
            float _HoloSpeed;
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float2 holographicOffset : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                // Calculer un offset basé sur la rotation de l'objet
                float rotationOffsetX = _Time.y * _HoloSpeed;
                float rotationOffsetY = _Time.y * _HoloSpeed;

                // Ajouter cet offset aux UVs pour décaler le motif holographique en fonction de la rotation
                o.holographicOffset = v.uv + float2(rotationOffsetX, rotationOffsetY) * _HoloScale;

                return o;
            }

            float4 HoloColor(float2 uv)
            {
                // Calculer un facteur de couleur en fonction des UVs
                float colorFactor = (sin(uv.x * 6.28) + 1.0) * 0.5;

                // Interpoler entre plusieurs couleurs pour créer l'effet holographique
                float4 holographicColor = lerp(_Color1, _Color2, colorFactor);
                holographicColor = lerp(holographicColor, _Color3, colorFactor * 0.5);

                return holographicColor;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Couleur de la texture principale de la carte
                fixed4 col = tex2D(_MainTex, i.uv);

                // Appliquer l'effet holographique avec l'offset dynamique basé sur la rotation
                float4 holoEffect = HoloColor(i.holographicOffset);

                // Mélanger la texture principale avec l'effet holographique
                float4 finalColor = lerp(col, holoEffect, _HoloIntensity);

                // Conserver l'alpha de la texture principale
                finalColor.a = col.a;

                return finalColor;
            }
            ENDCG
        }
    }

    FallBack "Transparent"
}
