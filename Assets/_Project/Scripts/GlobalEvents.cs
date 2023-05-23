using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents
{
    public static Action OnInit;
    public static Action OnRoll;
    public static Action OnTick;
    public static Action OnShowDice;
    public static Action<SideObj> OnSideClick;
    public static Action OnUpdateView;
    public static Action OnDiceUpgraded;
    public static Action OnRefreshShop;
    public static Action OnBuyDice;
    public static Action OnLevelUp;
    public static Action OnTenthRoundEnd;
}