using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditDice : MonoBehaviour
{
    private void ShowEdit()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void Hide()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}