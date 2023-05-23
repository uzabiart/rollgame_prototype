using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public int skipCost;
    public int cardCost;
    public int[] dicesCosts;
    public int[] roundsCosts;
    public int[] levelUpsCosts;
    int currLevel;
    int currRound;
    int currDice;
    int firstFreeSides = 3;
    int firstFreeSkips = 1;
    int coins;

    public int skipCostIncrement;
    public int cardCostIncrement;
    //public int roundCostIncrement;

    public static GameRules Instance;

    public List<SidesPerLevel> sidesPerLevel = new List<SidesPerLevel>();

    public TextMeshProUGUI rulesText;
    public TextMeshProUGUI coinsText;

    private void OnEnable()
    {
        GlobalEvents.OnDiceUpgraded += UpdateCost;
        GlobalEvents.OnTenthRoundEnd += UpdateRoundCost;
        GlobalEvents.OnRefreshShop += ShopRefreshed;
        GlobalEvents.OnBuyDice += BoughtDice;
        GlobalEvents.OnLevelUp += IncreaseLevel;
    }
    private void OnDisable()
    {
        GlobalEvents.OnDiceUpgraded -= UpdateCost;
        GlobalEvents.OnTenthRoundEnd -= UpdateRoundCost;
        GlobalEvents.OnRefreshShop -= ShopRefreshed;
        GlobalEvents.OnBuyDice -= BoughtDice;
        GlobalEvents.OnLevelUp -= IncreaseLevel;
    }

    private void Start()
    {
        Instance = this;
        GameManager.Instance.availableSides = sidesPerLevel[currLevel].sides;
        UpdateView();
    }

    public void IncreaseLevel()
    {
        coins -= levelUpsCosts[currLevel];
        currLevel++;
        GameManager.Instance.availableSides.AddRange(sidesPerLevel[currLevel].sides);
        UpdateView();
    }

    public void AddCoins(int value)
    {
        coins += value;
        UpdateView();
    }
    public void RemoveCoins(int value)
    {
        coins -= value;
        UpdateView();
    }

    private void BoughtDice()
    {
        coins -= dicesCosts[currDice];
        cardCost = (int)((((float)cardCost) + 0.5f) / 2f);
        currDice++;
        UpdateView();
    }

    private void ShopRefreshed()
    {
        if (firstFreeSkips > 0)
            firstFreeSkips--;
        else
            coins -= skipCost;

        UpdateView();
    }

    public void UpdateRoundCost()
    {
        coins -= roundsCosts[currRound];
        currRound += 1;
        UpdateView();
    }

    public void UpdateCost()
    {
        if (firstFreeSides > 0)
            firstFreeSides--;
        else
        {
            coins -= cardCost;
            cardCost += cardCostIncrement;
        }
        UpdateView();
    }

    public void UpdateView()
    {
        rulesText.text = $"RULES:\n" +
            $"First {firstFreeSides} Cards are free\n" +
            $"First {firstFreeSkips} Skip/s is/are free\n" +
            $"When you buy a Dice:\nCard cost / 2\n" +
            $"\n" +
            $"Card cost: {cardCost}\n" +
            $"Skip cost: {skipCost}\n" +
            $"Dice cost: {dicesCosts[currDice]}\n" +
            $"Level Up cost: {levelUpsCosts[currLevel]}\n" +
            $"\n" +
            $"Round #{(currRound + 1) * 10}: -{roundsCosts[currRound]}";

        coinsText.text = coins.ToString();
    }
}