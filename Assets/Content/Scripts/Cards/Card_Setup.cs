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

    public void CardSetup(CardData_ScriptableObject cardDataS)
    {
        _cardDataS = cardDataS;

        Debug.Log(cardDataS.CardData.Name + " Setup");

        _illustrationTopImage.sprite = cardDataS.CardData.IllustrationTop;

        if (cardDataS.CardData.VisualType == CardData.VISUAL_CARD_TYPE.DOUBLE)
        {
            _illustrationTransparentImage.sprite = cardDataS.CardData.IllustrationBot;
        }
        else
        {
            _illustrationTransparentImage.sprite = null;
        }


        _cardNameText.text = cardDataS.CardData.Name;
    }

}
