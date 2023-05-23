using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UMI/Dices/New Side")]
public class SideData : ScriptableObject
{
    public Sprite icon;
    public int addValue;
    public int weight;
    [TextArea(4, 10)]
    public string description;
}