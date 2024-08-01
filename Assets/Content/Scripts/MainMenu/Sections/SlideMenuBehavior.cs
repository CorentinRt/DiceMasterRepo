using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenuBehavior : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<Vector3> _positions;



    #endregion


    private void SlideTo(int indexPos)
    {
        if (indexPos >= _positions.Count)
            return;


    }
}
