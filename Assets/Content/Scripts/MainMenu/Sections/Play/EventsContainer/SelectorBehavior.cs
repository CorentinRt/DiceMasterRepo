using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectorBehavior : MonoBehaviour, IPointerClickHandler
{
    #region Fields
    
    private SlideMenuBehavior _slideMenu;

    private int _selectorIndex;

    [Header("Visuals")]
    [SerializeField] private Color _enableColor;
    [SerializeField] private Color _disableColor;

    private Image _image;

    #endregion

    #region Properties
    public int SelectorIndex { get => _selectorIndex; set => _selectorIndex = value; }
    public SlideMenuBehavior SlideMenu { get => _slideMenu; set => _slideMenu = value; }

    #endregion


    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        if (_slideMenu)
        { 
            _slideMenu.OnSlideTo += SetColor;

            SetColor(_slideMenu.StartIndex);
        }
        else
        {
            Debug.LogWarning("SlideMenu reference is missing ! Selector won't work !");
        }

    }
    private void OnDestroy()
    {
        if (_slideMenu)
        {
            _slideMenu.OnSlideTo -= SetColor;
        }
    }

    #region SetColors
    public void SetColor(int index)
    {
        if (index == _selectorIndex)
        {
            SetEnableColor();
        }
        else
        {
            SetDisableColor();
        }
    }
    private void SetEnableColor()
    {
        if (!_image)
            return;

        _image.color = _enableColor;
    }
    private void SetDisableColor()
    {
        if (!_image)
            return;

        _image.color = _disableColor;
    }
    #endregion

    #region Click
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_slideMenu)
            return;

        _slideMenu.SlideTo(_selectorIndex);
    }
    #endregion
}
