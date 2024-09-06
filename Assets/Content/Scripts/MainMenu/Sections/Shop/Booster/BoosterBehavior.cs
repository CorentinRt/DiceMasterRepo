using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoosterBehavior : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    private ShopBehavior _shopBehavior;

    #endregion


    private void Start()
    {
        _shopBehavior = ShopBehavior.Instance;
    }

    #region IPointer interfaces
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_shopBehavior == null)
            return;

        _shopBehavior.OpenBoosterOpener();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
