using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData_ScriptableObject : ScriptableObject
{
    private enum VISUAL_CARD_TYPE
    {
        SINGLE,
        DOUBLE
    }

    #region Fields
    [Header("Info")]
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
    public string Name { get => _name; set => _name = value; }
    
    #endregion
}
