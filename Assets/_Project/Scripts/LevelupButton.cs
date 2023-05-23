using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelupButton : MonoBehaviour
{
    public void OnClick()
    {
        GlobalEvents.OnLevelUp?.Invoke();
    }
}