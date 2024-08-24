using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    #region Fields
    private static ScenesManager _instance;

    [SerializeField] private string _menuSceneName;

    private float _asyncLoadPercent;


    #endregion

    #region Properties
    public static ScenesManager Instance { get => _instance; set => _instance = value; }


    #endregion

    public event Action<float> OnLoadProgress;


    private void Awake()
    {
        #region Singleton Setup
        if (_instance != null)
        {
            Debug.LogWarning("Two ScenesManager singleton conflicted ! One has been destroy on its awake !");
            Destroy(this.gameObject);
        }
        _instance = this;
        #endregion

        DontDestroyOnLoad(this);
    }


    #region Load Scene Methods
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }
    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            _asyncLoadPercent = asyncLoad.progress;

            OnLoadProgress?.Invoke(_asyncLoadPercent);

            yield return null;
        }
    }
    #endregion

    #region Pre Made Load Methods
    public void LoadMainMenuScene(bool async = false)
    {
        if (async)
        {
            LoadSceneAsync(_menuSceneName);
        }
        else
        {
            LoadScene(_menuSceneName);
        }
    }

    #endregion
}
