using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInspectionBehavior : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public enum INSPECTION_TYPE
    {
        TRIGGER_INSPECTION,
        INSPECTED
    }

    #region Fields

    [SerializeField] private INSPECTION_TYPE _inspectionType;

    [SerializeField, ShowIf("_inspectionType", INSPECTION_TYPE.INSPECTED)] private float _centerCardDuration;
    [SerializeField, ShowIf("_inspectionType", INSPECTION_TYPE.INSPECTED)] private float _inspectCardSpeed;

    private Card_Setup _cardSetup;

    private InspectionBehavior _inspectionBehavior;

    private Tween _centerTween;

    private Vector2 _lastMousePos;

    private Coroutine _inspectCoroutine;

    private bool _isInspecting;

    #endregion

    private void Start()
    {
        _cardSetup = GetComponent<Card_Setup>();

        _inspectionBehavior = InspectionBehavior.Instance;
    }

    #region IPointerHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (_inspectionType)
        {
            case INSPECTION_TYPE.TRIGGER_INSPECTION:
                if (_inspectionBehavior == null || _cardSetup == null)
                    return;

                _inspectionBehavior.OpenInspection(_cardSetup.CardDataS);

                break;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (_inspectionType)
        {
            case INSPECTION_TYPE.INSPECTED:

                StopCenterCard();

                _inspectCoroutine = StartCoroutine(InspectCoroutine());

                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (_inspectionType)
        {
            case INSPECTION_TYPE.INSPECTED:

                _isInspecting = false;

                StartCenterCard();

                break;
        }
    }
    #endregion

    #region CenterCard
    private void StartCenterCard()
    {
        _centerTween = gameObject.transform.DORotate(new Vector3(0, 0, 0), _centerCardDuration);

        _centerTween.Play();

    }
    private void StopCenterCard()
    {
       _centerTween?.Pause();
    }

    #endregion

    #region InspectCoroutine
    IEnumerator InspectCoroutine()
    {
        _isInspecting = true;

        _lastMousePos = Input.mousePosition;

        while (_isInspecting)
        {
            float deltaX = (Input.mousePosition.x - _lastMousePos.x) * Time.deltaTime * _inspectCardSpeed;
            float deltaY = (Input.mousePosition.y - _lastMousePos.y) * Time.deltaTime * _inspectCardSpeed;

            Vector3 tempVect = transform.rotation.eulerAngles;

            tempVect.y -= deltaX;
            tempVect.x += deltaY;

            transform.rotation = Quaternion.Euler(tempVect);

            _lastMousePos = Input.mousePosition;

            yield return null;
        }

        ResetInspectCoroutine();

        yield return null;
    }
    private void ResetInspectCoroutine()
    {
        _inspectCoroutine = null;
    }

    #endregion
}