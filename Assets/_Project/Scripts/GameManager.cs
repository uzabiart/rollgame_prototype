using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    None = 0,
    Gameplay = 10,
    Upgrade = 20,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SideData currentSide;
    public GameStates state;

    public List<SideData> availableSides = new List<SideData>();

    private void Start()
    {
        Instance = this;
        state = GameStates.Gameplay;
    }

    private void OnEnable()
    {
        GlobalEvents.OnSideClick += SideClick;
    }

    private void OnDisable()
    {
        GlobalEvents.OnSideClick -= SideClick;
    }

    public void SideClick(SideObj obj)
    {
        if (state == GameStates.Gameplay)
        {
            if (currentSide == null || currentSide != obj.data)
            {
                currentSide = obj.data;
            }
            else
            {
                currentSide = null;
            }
        }
        if (state == GameStates.Upgrade)
        {
            if (currentSide != GlobalData.CurrentDice.sides[obj.id].data)
            {
                GlobalEvents.DiceUpgraded?.Invoke();
                GlobalData.CurrentDice.sides[obj.id].UpdateSide(currentSide);
                currentSide = null;
            }
        }

        GlobalEvents.UpdateView?.Invoke();
    }

    public void ChangeGameState(GameStates newState)
    {
        state = newState;
    }
}