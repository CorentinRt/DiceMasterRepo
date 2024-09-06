using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    #region Fields
    private static ShopBehavior _instance;

    [SerializeField] private GameObject _boosterOpener;


    #endregion

    #region Properties
    public static ShopBehavior Instance { get => _instance; set => _instance = value; }

    #endregion

    private void Awake()
    {
        #region Singleton Setup
        if (_instance != null)
        {
            Debug.LogWarning("Two ShopBehavior singleton conflicted ! One has been destroy on its awake !");
            Destroy(this.gameObject);
        }

        _instance = this;
        #endregion
    }

    #region Booster Opener
    public void OpenBoosterOpener()
    {
        _boosterOpener.SetActive(true);
    }
    public void CloseBoosterOpener()
    {
        _boosterOpener.SetActive(false);
    }
    #endregion
}
