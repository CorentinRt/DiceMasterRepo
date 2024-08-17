using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData_ScriptableObject : ScriptableObject
{
    #region Fields
    [Header("Info")]
    [SerializeField] private string _name;

    [Space(20)]

    [Header("Visuals")]
    [SerializeField] private Sprite _illustrationTop;
    [SerializeField] private Sprite _illustrationBot;

    [Space(20)]

    [Header("Stats")]
    [SerializeField] private int _cost;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;

    #endregion
}
