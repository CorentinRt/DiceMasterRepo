using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsInventoryData", menuName = "ScriptableObjects/CardsInventoryData", order = 1)]
public class CardsInventoryData_ScriptableObject : ScriptableObject     // This includes all existing cards and not only the cards the player owns
{
    [SerializeField] private List<CardData_ScriptableObject> _cardsData;

    public List<CardData_ScriptableObject> CardsData { get => _cardsData; set => _cardsData = value; }
}

