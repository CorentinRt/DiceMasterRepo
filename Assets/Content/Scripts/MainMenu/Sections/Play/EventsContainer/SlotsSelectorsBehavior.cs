using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsSelectorsBehavior : MonoBehaviour
{
    #region Fields
    [Header("Setup")]

    [SerializeField] private SlideMenuBehavior _slideMenu;
    [SerializeField] private GameObject _selectorPrefab;

    #endregion


    private void Reset()
    {
        if (transform.parent.TryGetComponent<SlideMenuBehavior>(out SlideMenuBehavior slideMenu))
        {
            _slideMenu = slideMenu;
        }
    }
    private void Start()
    {
        if (!_slideMenu)
        {
            Debug.LogWarning("No slide Menu attached to this SlotsSelectors ! It won't work properly !");
            return;
        }

        SetupSelectors(_slideMenu.Positions.Count);
    }


    #region Setup Selectors
    private void SetupSelectors(int slotsNumber)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            GameObject selector = Instantiate(_selectorPrefab, transform);

            SelectorBehavior selectorB = selector.GetComponent<SelectorBehavior>();
            selectorB.SelectorIndex = i;
            selectorB.SlideMenu = _slideMenu;
        }
    }
    #endregion
}
