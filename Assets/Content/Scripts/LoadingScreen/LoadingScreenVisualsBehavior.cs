using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenVisualsBehavior : MonoBehaviour
{
    #region Fields
    [Header("Elements")]
    [SerializeField] private Slider _loadingBar;

    [Header("Triggers")]
    [SerializeField] private ScenesManager _scenesManager;

    #endregion

    private void Start()
    {
        if (_scenesManager != null)
        {
            _scenesManager.OnLoadProgress += UpdateLoadingBarVisuals;
        }
        else
        {
            Debug.LogWarning("SceneManager reference missing in loading screen visuals behavior ! Visuals won't work properly !");
        }
    }
    private void OnDestroy()
    {
        if (_scenesManager != null)
        {
            _scenesManager.OnLoadProgress -= UpdateLoadingBarVisuals;
        }
    }

    private void UpdateLoadingBarVisuals(float percent)
    {
        _loadingBar.value = percent;
    }

}
