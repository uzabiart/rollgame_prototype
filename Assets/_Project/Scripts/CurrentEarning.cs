using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentEarning : MonoBehaviour
{
    public int currentEarning;
    public TMP_InputField input;

    public void UpdateValue(string value)
    {
        currentEarning = int.Parse(value);
    }

    public void Add()
    {
        if (AutobattlerRules.Instance != null)
            AutobattlerRules.Instance.AddCoins(currentEarning);
        if (GameRulesBattlegrounds.Instance != null)
            GameRulesBattlegrounds.Instance.AddCoins(currentEarning);
        if (GameRules.Instance != null)
            GameRules.Instance.AddCoins(currentEarning);
        ResetValue();
    }
    public void Remove()
    {
        if (AutobattlerRules.Instance != null)
            AutobattlerRules.Instance.RemoveCoins(currentEarning);
        if (GameRulesBattlegrounds.Instance != null)
            GameRulesBattlegrounds.Instance.RemoveCoins(currentEarning);
        if (GameRules.Instance != null)
            GameRules.Instance.RemoveCoins(currentEarning);
        ResetValue();
    }

    public void ResetValue()
    {
        input.text = "0";
        currentEarning = 0;
    }
}