using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBehavior : MonoBehaviour
{
    #region
    private SaveLoadDataJSON _loadDataJSON;

    private Dictionary<string, GameObject> _cardsCollection;

    private CardsInventoryData_ScriptableObject _cardsInventoryData;

    [Header("Setup")]
    [SerializeField] private RectTransform _cardContainer;
    [SerializeField] private GameObject _cardUIPrefab;

    #endregion

    private void Awake()
    {
        _cardsCollection = new Dictionary<string, GameObject>();
    }
    private void Start()
    {
        _loadDataJSON = SaveLoadDataJSON.Instance;

        if (_loadDataJSON != null)
        {
            _cardsInventoryData = _loadDataJSON.CardsInventoryData;
        }

        SetupCollectionCards();
    }

    #region Setup Collection Cards
    private void SetupCollectionCards()
    {
        if (_loadDataJSON == null)
            return;

        //Debug.Log("Setup Collection Cards");

        List<CardData_ScriptableObject> cardsSavedData = _cardsInventoryData.CardsData;

        foreach (CardData_ScriptableObject cardDataS in cardsSavedData)
        {
            GameObject currentCard = Instantiate(_cardUIPrefab, _cardContainer);
            currentCard.SetActive(true);
            _cardsCollection[cardDataS.CardData.Name] = currentCard;

            currentCard.GetComponent<Card_Setup>().CardSetup(cardDataS);

            if (!cardDataS.CardData.Unlocked)
            {
                currentCard.SetActive(false);
            }
        }
    }
    #endregion


}
