using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    public ToggleLogic[] toggles;
    public TextMeshProUGUI txt;

    int currToggle;

    public void OnClick()
    {
        toggles[currToggle].onClick?.Invoke();

        currToggle++;
        if (currToggle >= toggles.Length)
            currToggle = 0;

        txt.text = toggles[currToggle].text;
    }
}

[System.Serializable]
public class ToggleLogic
{
    public string text;
    public UnityEvent onClick;
}