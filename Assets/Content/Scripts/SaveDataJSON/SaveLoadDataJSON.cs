using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;


public class SaveLoadDataJSON : MonoBehaviour
{
    #region Fields

    private static SaveLoadDataJSON _instance;

    [Header("Automatic Setup ?")]
    [SerializeField] private bool _automaticLaunchSetup;

    [Space(20)]

    [Header("Cards Saves")]
    private CardData_ScriptableObject _currentCardData;

    private string _saveFilePathPrefix;
    private string _saveFilePathSuffix = ".json";

    [SerializeField] private CardsInventoryData_ScriptableObject _cardsInventoryData;


    #endregion

    #region Properties
    public static SaveLoadDataJSON Instance { get => _instance; set => _instance = value; }

    #endregion

    public UnityEvent OnSetupLoadFinishedUnity;


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Two SaveDataJson singleton conflicted ! One has been destroy on its awake !");
            Destroy(this.gameObject);
        }
        
        _instance = this;

        _saveFilePathPrefix = Application.persistentDataPath + "/";

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (_automaticLaunchSetup)
        {
            SetupCardsInventoryJSON();
        }
    }

    #region Card Data Setup and Methods
    private void SetupCardsInventoryJSON()
    {
        foreach (CardData_ScriptableObject cardDataS in _cardsInventoryData.CardsData)   // Pour toutes les cartes existantes dans le jeu
        {
            if (!File.Exists(_saveFilePathPrefix + cardDataS.CardData.Name + _saveFilePathSuffix))    // Si le fichier de sauvegarde de la carte n'existe pas déjà alors on le crée
            {
                SaveCardDataJSON(cardDataS);
            }
            else     // Si le fichier existe déjà alors l'inventaire prends les infos du json et re-sauvegarde avec les infos à jour pour pouvoir re-mettre le bon path de l'image
            {
                CardData tempCardData = LoadCardDataJSON(cardDataS.CardData.Name);
                cardDataS.CardData = tempCardData;
                SaveCardDataJSON(cardDataS);
            }
        }

        OnSetupLoadFinishedUnity?.Invoke();
    }

    #region Saves
    private void SaveAllCardsInventory(CardsInventoryData_ScriptableObject cardsInventory)
    {
        foreach (CardData_ScriptableObject cardDataS in cardsInventory.CardsData)
        {
            SaveCardDataJSON(cardDataS);
        }
    }
    public void SaveCardDataJSON(CardData_ScriptableObject cardData)
    {
        _currentCardData = cardData;

        string saveCardData = JsonUtility.ToJson(_currentCardData.CardData);
        File.WriteAllText(_saveFilePathPrefix + cardData.CardData.Name + _saveFilePathSuffix, saveCardData);

        Debug.Log("Save file created at: " + _saveFilePathPrefix + cardData.CardData.Name + _saveFilePathSuffix);
    }
    #endregion

    #region Loads

    public CardData LoadCardDataJSON(string cardName)
    {
        if (File.Exists(_saveFilePathPrefix + cardName + _saveFilePathSuffix))
        {
            CardData cardData = new CardData();

            string LoadCardData = File.ReadAllText(_saveFilePathPrefix + cardName + _saveFilePathSuffix);
            cardData = JsonUtility.FromJson<CardData>(LoadCardData);

            Debug.Log("Load card complete! \nCard name: " + cardData.Name);

            return cardData;
        }
        else
        {
            Debug.Log("There is no save files to load!");
            return null;
        }
    }
    public List<CardData> LoadAllCardsDataJSON()
    {
        List<CardData> cardsSavedData;
        cardsSavedData = new List<CardData>();

        foreach (CardData_ScriptableObject cardDataS in _cardsInventoryData.CardsData)
        {
            cardsSavedData.Add(LoadCardDataJSON(cardDataS.CardData.Name));
        }

        return cardsSavedData;
    }
    #endregion

    #endregion



    #region UpdateCardsInventory
    public void UpdateCardToInventory()
    {
        
    }


    #endregion
}
