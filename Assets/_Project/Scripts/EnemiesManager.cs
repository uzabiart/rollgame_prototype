using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject[] enemies;
    int currFight;

    public void SetupFight()
    {
        HideFight();
        enemies[currFight].SetActive(true);
        currFight++;
    }

    public void HideFight()
    {
        foreach (GameObject g in enemies)
        {
            g.SetActive(false);
        }
    }
}