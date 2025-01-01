using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterOpenEffects : MonoBehaviour
{
    #region Fields

    private RectTransform _rectTransform;


    [SerializeField] private Image _boosterImage;

    [SerializeField] private Color _openTargetColor;
    [SerializeField] private Color _classicColor;

    [SerializeField] private float _openEffectDuration;

    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _shakeVibrato;

    [SerializeField] private Vector3 _openTargetScaleEffect;

    private Tween _colorChangeTween;
    private Tween _shakeTween;
    private Tween _scaleTween;

    #endregion


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

        _boosterImage.color = _classicColor;
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

        _colorChangeTween = _boosterImage.DOColor(_openTargetColor, _openEffectDuration);
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

        _scaleTween = _boosterImage.rectTransform.DOPunchScale(_openTargetScaleEffect, _openEffectDuration, 2, 1);
    }
    #endregion

    #endregion
}
