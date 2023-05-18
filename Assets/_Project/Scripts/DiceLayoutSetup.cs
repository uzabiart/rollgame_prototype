using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceLayoutSetup : MonoBehaviour
{
    public List<SideObj> sides = new List<SideObj>();

    private void OnEnable()
    {
        for (int i = 0; i < sides.Count; i++)
        {
            sides[i].Setup(GlobalData.CurrentDice.sides[i].data, i);
        }
    }
}