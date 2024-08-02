using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlideMenuBehavior : MonoBehaviour
{
    private enum SLIDE_MENU_TYPE
    {
        MANUAL,
        AUTOMATIC
    }

    #region Fields
    [Header("Setup")]
    [SerializeField] private RectTransform _slideAnchor;

    [SerializeField] private List<RectTransform> _positions;

    [Header("Modifiers")]
    [SerializeField] private int _startIndex;
    private int _currentIndex;

    [SerializeField] private float _transitionTime;

    [SerializeField] private SLIDE_MENU_TYPE _slideType;

    [SerializeField, Range(1f, 10f), ShowIf("IsAutomatic")] private float _timeBetweenAutomaticSlides;

    private Coroutine _automaticSlideCoroutine;

    #endregion

    #region Properties
    public bool IsAutomatic { get => _slideType == SLIDE_MENU_TYPE.AUTOMATIC; }

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
    private void SlideTo1() => SlideTo(0);
    [Button, ShowIf("IsPlayMode")]
    private void SlideTo2() => SlideTo(1);
    [Button, ShowIf("IsPlayMode")]
    private void SlideTo3() => SlideTo(2);
    [Button, ShowIf("IsPlayMode")]
    private void SlideTo4() => SlideTo(3);
    [Button, ShowIf("IsPlayMode")]
    private void SlideTo5() => SlideTo(4);
    #endregion

    private void Awake()
    {
        if (_startIndex < _positions.Count)
        {
            Vector3 tempVect = _slideAnchor.localPosition;

            tempVect.x = -_positions[_startIndex].localPosition.x;

            _slideAnchor.localPosition = tempVect;
        }

        _currentIndex = _startIndex;

        if (_slideType == SLIDE_MENU_TYPE.AUTOMATIC)
        {
            _timeBetweenAutomaticSlides = Mathf.Clamp(_timeBetweenAutomaticSlides, 1f, 10f);

            _automaticSlideCoroutine = StartCoroutine(AutomaticSlideCoroutine());
        }
    }

    #region Slide
    public void SlideTo(int indexPos)
    {
        if (indexPos >= _positions.Count)
            return;

        _currentIndex = indexPos;
        Debug.Log("Slide");
        _slideAnchor.DOLocalMoveX(-_positions[indexPos].localPosition.x, _transitionTime);
    }

    private IEnumerator AutomaticSlideCoroutine()
    {
        while (IsAutomatic)
        {
            yield return new WaitForSeconds(_timeBetweenAutomaticSlides);

            if (_currentIndex + 1 >= _positions.Count)
            {
                SlideTo(0);
            }
            else
            {
                SlideTo(_currentIndex + 1);
            }
        }
        yield return null;
    }
    #endregion
}
