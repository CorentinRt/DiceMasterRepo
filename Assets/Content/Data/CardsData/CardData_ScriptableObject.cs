using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardData;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData_ScriptableObject : ScriptableObject
{
    #region Fields
    [SerializeField] private CardData _cardData;

    [Space(40)]

    [Header("Visuals")]
    [SerializeField] VISUAL_CARD_TYPE _visualType;
    [SerializeField] private Sprite _illustrationTop;
    [SerializeField, ShowIf("_visualType", VISUAL_CARD_TYPE.DOUBLE)] private Sprite _illustrationBot;

    #endregion

    #region Properties
    public CardData CardData { get => _cardData; set => _cardData = value; }

    public VISUAL_CARD_TYPE VisualType { get => _visualType; set => _visualType = value; }
    public Sprite IllustrationTop { get => _illustrationTop; set => _illustrationTop = value; }
    public Sprite IllustrationBot { get => _illustrationBot; set => _illustrationBot = value; }
    #endregion
}

[System.Serializable]
public class CardData
{
    public enum VISUAL_CARD_TYPE
    {
        SINGLE,
        DOUBLE
    }
    public enum UPGRADE_CARD_LEVEL
    {
        BASIC,
        SHINY,
        HOLOGRAPHIC
    }
    public enum RARITY_CARD_TYPE
    {
        BRONZE,
        SILVER,
        GOLD,
        DIAMOND
    }

    #region Fields
    [Header("Data Tools (Don't modify !)")]
    [SerializeField] private int _indexInventory;

    [Space(40)]

    [Header("Info")]
    [SerializeField] private string _name;
    [SerializeField] private bool _unlocked;
    [SerializeField] private UPGRADE_CARD_LEVEL _upgradeLevel;
    [SerializeField] private RARITY_CARD_TYPE _rarity;

    [SerializeField] private int _cardCopyPossessed;

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
    public int Cost { get => _cost; set => _cost = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public UPGRADE_CARD_LEVEL UpgradeLevel { get => _upgradeLevel; set => _upgradeLevel = value; }
    public RARITY_CARD_TYPE Rarity { get => _rarity; set => _rarity = value; }

    #endregion
}