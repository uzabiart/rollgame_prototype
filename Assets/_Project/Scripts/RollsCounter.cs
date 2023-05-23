using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollsCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    int currCounter;

    private void OnEnable()
    {
        GlobalEvents.OnRoll += IncreaseCounter;
    }
    private void OnDisable()
    {
        GlobalEvents.OnRoll -= IncreaseCounter;
    }

    public void IncreaseCounter()
    {
        currCounter++;
        counter.text = $"ROUND:\n{currCounter.ToString()}";
        if (currCounter % 10 == 0)
            GlobalEvents.OnTenthRoundEnd?.Invoke();
    }
}