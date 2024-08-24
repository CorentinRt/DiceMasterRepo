using NaughtyAttributes;
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

    [SerializeField] CardData_ScriptableObject _scriptableObject;

    #endregion

    [Button]
    public void SetupArakar()
    {
        CardSetup(_scriptableObject.CardData);
    }

    public void CardSetup(CardData cardData)
    {
        Debug.Log("test1");
        if (cardData.IllustrationTop == null)
        {
            Debug.Log("Test1.5");
        }
        _illustrationTopImage.sprite = cardData.IllustrationTop;
        Debug.Log("test2");
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
