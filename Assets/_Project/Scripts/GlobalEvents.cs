using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents
{
    public static Action OnRoll;
    public static Action OnShowDice;
    public static Action<SideObj> OnSideClick;
    public static Action UpdateView;
    public static Action DiceUpgraded;
}