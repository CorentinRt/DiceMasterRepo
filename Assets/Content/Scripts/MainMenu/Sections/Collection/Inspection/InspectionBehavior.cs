using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionBehavior : MonoBehaviour
{
    #region Fields
    private static InspectionBehavior _instance;

    [SerializeField] private Canvas _canvas;

    [SerializeField] private GameObject _cardUIInspected;


    #endregion
    #region Properties
    public static InspectionBehavior Instance { get => _instance; set => _instance = value; }

    #endregion

    private void Awake()
    {
        #region Singleton Setup
        if (_instance != null)
        {
            Debug.LogWarning("Two InspectionBehavior singleton conflicted ! One has been destroy on its awake !");
            Destroy(this.gameObject);
        }

        _instance = this;
        #endregion

    }
    private void Start()
    {
        CloseInspection();
    }

    #region Open/Close
    public void OpenInspection(CardData_ScriptableObject cardDataS)
    {
        if (cardDataS == null)
            return;

        ChangeInspectedCard(cardDataS);

        _canvas.gameObject.SetActive(true);
    }
    public void CloseInspection()
    {
        _canvas.gameObject.SetActive(false);
    }
    #endregion

    #region Change Inspected Card
    public void ChangeInspectedCard(CardData_ScriptableObject cardDataS)
    {
        Card_Setup cardSetup = _cardUIInspected.GetComponent<Card_Setup>();

        cardSetup.CardSetup(cardDataS);
    }
    #endregion
}
