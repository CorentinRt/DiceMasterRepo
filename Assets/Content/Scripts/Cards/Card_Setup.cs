using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card_Setup : MonoBehaviour
{
    #region Fields
    [Header("Visuals")]
    [SerializeField] private Image _illustrationTopImage;
    [SerializeField] private Image _illustrationTransparentImage;

    [Header("Info")]
    [SerializeField] private TextMeshProUGUI _cardNameText;

    #endregion

    public void CardSetup(CardData cardData)
    {
        _illustrationTopImage.sprite = cardData.IllustrationTop;
        if (cardData.VisualType == CardData.VISUAL_CARD_TYPE.DOUBLE)
        {
            _illustrationTransparentImage.sprite = cardData.IllustrationBot;
        }
        else
        {
            _illustrationTransparentImage.sprite = null;
        }


        _cardNameText.text = cardData.Name;
    }

}
