using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardUpgradeEffects", menuName = "ScriptableObjects/CardUpgradeEffects", order = 1)]
public class CardUpgradeEffects_ScriptableObject : ScriptableObject
{
    #region Fields
    [SerializeField] private Material _shinyMaterial;

    [SerializeField] private Material _holographicMaterial;

    #endregion

    #region Properties
    public Material ShinyMaterial { get => _shinyMaterial; set => _shinyMaterial = value; }
    public Material HolographicMaterial { get => _holographicMaterial; set => _holographicMaterial = value; }


    #endregion

}
