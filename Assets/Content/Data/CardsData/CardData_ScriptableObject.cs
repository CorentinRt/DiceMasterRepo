using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData_ScriptableObject : ScriptableObject
{
    [SerializeField] private CardData _cardData;

    public CardData CardData { get => _cardData; set => _cardData = value; }
}

[System.Serializable]
public class CardData
{
    public enum VISUAL_CARD_TYPE
    {
        SINGLE,
        DOUBLE
    }

    #region Fields
    [Header("Info")]
    private int _indexInventory;
    [SerializeField] private string _name;
    [SerializeField] private bool _unlocked;

    [Space(20)]

    [Header("Visuals")]
    [SerializeField] VISUAL_CARD_TYPE _visualType;
    [SerializeField] private Sprite _illustrationTop;
    [SerializeField, ShowIf("_visualType", VISUAL_CARD_TYPE.DOUBLE)] private Sprite _illustrationBot;

    [Space(20)]

    [Header("Stats")]
    [SerializeField] private int _cost;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;


    #endregion

    #region Properties
    public int IndexInventory { get => _indexInventory; set => _indexInventory = value; }
    public string Name { get => _name; set => _name = value; }
    public bool Unlocked { get => _unlocked; set => _unlocked = value; }
    public VISUAL_CARD_TYPE VisualType { get => _visualType; set => _visualType = value; }
    public Sprite IllustrationTop { get => _illustrationTop; set => _illustrationTop = value; }
    public Sprite IllustrationBot { get => _illustrationBot; set => _illustrationBot = value; }

    #endregion
}