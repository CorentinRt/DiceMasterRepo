using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoosterOpenerBehavior : MonoBehaviour
{
    #region Fields

    [SerializeField] private Card_Setup _openedCardSetup;

    [SerializeField] private BoosterBehavior _openingBoosterBehavior;

    public UnityEvent OnOpenBoosterOpenerUnity;

    #endregion


    #region Open / Close
    public void OpenBoosterOpener()
    {
        gameObject.SetActive(true);

        OnOpenBoosterOpenerUnity?.Invoke();
    }

    public void CloseBoosterOpener()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Appear Card In Booster
    public void AppearRandomCardInBooster()
    {
        if (_openedCardSetup == null || _openingBoosterBehavior == null)
            return;

        CardData_ScriptableObject tempCardDataS = _openingBoosterBehavior.GetRandomCardDataSInBooster();

        if (tempCardDataS == null)
            return;

        _openedCardSetup.CardSetup(tempCardDataS);

        _openedCardSetup.gameObject.SetActive(true);
    }

    #endregion
}
