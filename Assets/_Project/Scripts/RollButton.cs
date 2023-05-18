using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    public void OnClick()
    {
        GlobalEvents.OnRoll?.Invoke();
    }
}