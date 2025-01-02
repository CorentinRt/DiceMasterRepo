using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;


public enum BoosterInspectionType
{
    TRIGGER_INSPECTION,
    INSPECTED
}
public class BoosterBehavior : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    #region Fields
    private ShopBehavior _shopBehavior;

    [SerializeField] private BoosterOpenEffects _boosterOpenEffects;
    [SerializeField] private BoosterInspectionType _boosterInspectionType;

    [SerializeField] private List<CardData_ScriptableObject> _cardDataSInBooster;
    #endregion

    public event Action OnOpenbooster;


    private void Start()
    {
        _shopBehavior = ShopBehavior.Instance;
    }

    #region IPointer interfaces
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (_boosterInspectionType)
        {
            case BoosterInspectionType.TRIGGER_INSPECTION:
                if (_shopBehavior == null)
                    return;

                _shopBehavior.OpenBoosterOpener();
                break;

            case BoosterInspectionType.INSPECTED:

                break;

            default:
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
    #endregion

    #region Open Booster

    public void OpenBooster()
    {
        OnOpenbooster?.Invoke();

        if (_boosterOpenEffects != null)
        {
            _boosterOpenEffects.TriggerOpenBoosterEffects();
        }
    }

    #endregion

    public CardData_ScriptableObject GetRandomCardDataSInBooster()
    {
        int randIndex = 0;

        randIndex = (int)Random.Range(0f, _cardDataSInBooster.Count);

        if (randIndex < 0 || randIndex > _cardDataSInBooster.Count)
            return null;

        return _cardDataSInBooster[randIndex];
    }
}
