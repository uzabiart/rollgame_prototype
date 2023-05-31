using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRules_Icons : MonoBehaviour
{
    public int skipCost;
    public int cardCost;
    public int[] dicesCosts;
    public int[] roundsCosts;
    public int[] levelUpsCosts;
    int currLevel;
    int currRound;
    int currDice;
    int firstFreeSides = 0;
    int firstFreeSkips = 0;
    int coins;

    public int skipCostIncrement;
    public int cardCostIncrement;
    //public int roundCostIncrement;

    public static GameRules_Icons Instance;

    public List<SidesPerLevel> sidesPerLevel = new List<SidesPerLevel>();

    public TextMeshProUGUI rulesText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI levelText;

    private void OnEnable()
    {
        GlobalEvents.OnInit += Init;
        GlobalEvents.OnDiceUpgraded += UpdateCost;
        GlobalEvents.OnTenthRoundEnd += UpdateRoundCost;
        GlobalEvents.OnRefreshShop += ShopRefreshed;
        GlobalEvents.OnBuyDice += BoughtDice;
        GlobalEvents.OnLevelUp += IncreaseLevel;
    }
    private void OnDisable()
    {
        GlobalEvents.OnInit -= Init;
        GlobalEvents.OnDiceUpgraded -= UpdateCost;
        GlobalEvents.OnTenthRoundEnd -= UpdateRoundCost;
        GlobalEvents.OnRefreshShop -= ShopRefreshed;
        GlobalEvents.OnBuyDice -= BoughtDice;
        GlobalEvents.OnLevelUp -= IncreaseLevel;
    }

    private void Init()
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

    [TextArea(2, 5)]
    public string[] addedRules;

    public void UpdateView()
    {
        string moreRules = "";
        foreach (string r in addedRules)
        {
            moreRules += r + "\n";
        }
        moreRules += "\n";

        rulesText.text = $"RULES:\n" +
            $"{moreRules}" +
            $"Card cost: {cardCost}\n" +
            $"Skip cost: {skipCost}\n" +
            $"Dice cost: {dicesCosts[currDice]}\n" +
            $"Level Up cost: {levelUpsCosts[currLevel]}\n" +
            $"\n" +
            $"When you level up:\n" +
            $"+1 available Card";

        levelText.text = $"LEVEL:\n{currLevel + 1}";
        coinsText.text = coins.ToString();
    }
}
