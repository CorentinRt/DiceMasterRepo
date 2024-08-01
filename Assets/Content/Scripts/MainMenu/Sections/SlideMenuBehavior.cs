using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlideMenuBehavior : MonoBehaviour
{
    #region Fields
    [SerializeField] private RectTransform _slideAnchor;

    [SerializeField] private List<RectTransform> _positions;

    [SerializeField] private float _transitionTime;

    #endregion

    #region Check PlayMode
    private bool IsPlayMode()
    {
#if UNITY_EDITOR
        return Application.isPlaying;
#else
            return false;
#endif
    }
    #endregion

    #region Test Slide
    [Button, ShowIf("IsPlayMode")]
    private void SlideToShop() => SlideTo(0);
    [Button, ShowIf("IsPlayMode")]
    private void SlideToCollection() => SlideTo(1);
    [Button, ShowIf("IsPlayMode")]
    private void SlideToPlay() => SlideTo(2);
    [Button, ShowIf("IsPlayMode")]
    private void SlideToEvents() => SlideTo(3);
    [Button, ShowIf("IsPlayMode")]
    private void SlideToNews() => SlideTo(4);
    #endregion

    #region Slide
    public void SlideTo(int indexPos)
    {
        if (indexPos >= _positions.Count)
            return;

        Debug.Log("Slide");
        _slideAnchor.DOLocalMoveX(-_positions[indexPos].localPosition.x, _transitionTime);
    }
    #endregion
}
