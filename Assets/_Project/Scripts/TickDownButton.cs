using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickDownButton : MonoBehaviour
{
    public void OnClick()
    {
        GlobalEvents.OnTick?.Invoke();
    }
}