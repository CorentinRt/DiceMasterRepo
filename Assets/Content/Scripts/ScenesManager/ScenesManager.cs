using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private string _menuSceneName;

    private float _asyncLoadPercent;

    #endregion

    public event Action<float> OnLoadProgress;


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
