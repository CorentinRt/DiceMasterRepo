using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoosterOpenEffects : MonoBehaviour
{
    #region Fields

    private RectTransform _rectTransform;


    [SerializeField] private Image _boosterImage;
    [SerializeField] private Image _boosterImageOpening;

    [SerializeField] private float _openEffectDuration;

    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _shakeVibrato;

    [SerializeField] private Vector3 _openTargetScaleEffect;

    private Tween _colorChangeTween;
    private Tween _shakeTween;
    private Tween _scaleTween;

    #endregion

    public UnityEvent OnBoosterOpenEffectsEndUnity;


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    #region Open Booster Effects
    public void InitBoosterVisual()
    {
        if (_colorChangeTween != null)
        {
            _colorChangeTween.Complete();
        }
        if (_shakeTween != null)
        {
            _shakeTween.Complete();
        }
        if (_scaleTween != null)
        {
            _scaleTween.Complete();
        }

        gameObject.SetActive(true);

        _boosterImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);

        Color tempTranspColor = Color.white;
        tempTranspColor.a = 0f;
        _boosterImageOpening.color = tempTranspColor;
    }

    public void TriggerOpenBoosterEffects()
    {
        ColorChangeEffect();

        ShakeBoosterEffect();

        ScaleEffect();
    }

    #region Effects
    private void ColorChangeEffect()
    {
        if (_colorChangeTween != null)
        {
            _colorChangeTween.Complete();
        }

        _colorChangeTween = _boosterImageOpening.DOFade(1f, _openEffectDuration).OnComplete(() => EndOpenEffects());
    }
    private void ShakeBoosterEffect()
    {
        if (_rectTransform ==  null)
            return;

        if (_shakeTween != null)
        {
            _shakeTween.Complete();
        }

        _shakeTween = _rectTransform.DOShakeAnchorPos(_openEffectDuration, _shakeStrength, _shakeVibrato);
    }
    private void ScaleEffect()
    {
        if (_scaleTween != null)
        {
            _scaleTween.Complete();
        }

        _scaleTween = _boosterImage.rectTransform.DOScale(_openTargetScaleEffect, _openEffectDuration);
    }
    #endregion

    private void EndOpenEffects()
    {
        OnBoosterOpenEffectsEndUnity?.Invoke();

        gameObject.SetActive(false);
    }

    #endregion
}
