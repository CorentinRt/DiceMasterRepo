using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBehavior : MonoBehaviour
{
    #region
    private SaveLoadDataJSON _loadDataJSON;

    private Dictionary<string, GameObject> _cardsCollection;

    private List<CardData> _cardsSavedData;

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
            _cardsSavedData = _loadDataJSON.LoadAllCardsDataJSON();
        }

        SetupCollectionCards();
    }

    #region Setup Collection Cards
    private void SetupCollectionCards()
    {
        if (_loadDataJSON == null)
            return;

        Debug.Log("Setup Collection Cards");

        foreach (CardData cardData in _cardsSavedData)
        {
            GameObject currentCard = Instantiate(_cardUIPrefab, _cardContainer);
            currentCard.SetActive(true);
            Debug.Log("Instantiate, " + cardData.Name);
            Debug.Log("Instantiate, " + cardData.IllustrationTop.GetType());
            _cardsCollection[cardData.Name] = currentCard;

            currentCard.GetComponent<Card_Setup>().CardSetup(cardData);

            if (!cardData.Unlocked)
            {
                currentCard.SetActive(false);
            }
        }
    }
    #endregion


}
