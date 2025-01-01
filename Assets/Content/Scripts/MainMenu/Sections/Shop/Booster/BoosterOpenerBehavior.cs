using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoosterOpenerBehavior : MonoBehaviour
{
    #region Fields

    [SerializeField] private BoosterBehavior _openingBoosterBehavior;


    public UnityEvent OnOpenBoosterOpenerUnity;

    #endregion

    private void Start()
    {
        if (_openingBoosterBehavior != null)
        {
            
        }
    }

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

}
