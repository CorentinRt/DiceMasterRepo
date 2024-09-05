using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card_Setup : MonoBehaviour
{
    #region Fields
    [Header("Info")]
    private CardData_ScriptableObject _cardDataS;
    
    [Header("Visuals")]
    [SerializeField] private Image _illustrationTopImage;
    [SerializeField] private Image _illustrationTransparentImage;
    [SerializeField] private TextMeshProUGUI _cardNameText;


    #endregion

    #region Properties
    public CardData_ScriptableObject CardDataS { get => _cardDataS; set => _cardDataS = value; }


    #endregion

    #region Card Setup
    public void CardSetup(CardData_ScriptableObject cardDataS)
    {
        _cardDataS = cardDataS;

        Debug.Log(cardDataS.CardData.Name + " Setup");

        _illustrationTopImage.sprite = cardDataS.IllustrationTop;

        if (cardDataS.VisualType == CardData.VISUAL_CARD_TYPE.DOUBLE)
        {
            _illustrationTransparentImage.sprite = cardDataS.IllustrationBot;
        }
        else
        {
            _illustrationTransparentImage.sprite = null;
        }

        _cardNameText.text = GetDisplayName(cardDataS.CardData.Name);
    }

    private string GetDisplayName(string name)
    {
        string displayName = "";

        for (int i = 0; i < name.Length; i++)
        {
            displayName += name[i];

            if (i + 1 < name.Length)
            {
                if (char.IsUpper(name[i + 1]))
                {
                    displayName += " ";
                }
            }
        }

        return displayName;
    }

    #endregion

}
