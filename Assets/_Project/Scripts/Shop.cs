using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Shop : MonoBehaviour
{
    public List<SideData> shopSides = new List<SideData>();

    public List<SideObj> sideobjects = new List<SideObj>();
    public Transform parent;

    private void Start()
    {
        GetSides();
    }

    private void OnEnable()
    {
        GlobalEvents.DiceUpgraded += Hide;
    }
    private void OnDisable()
    {
        GlobalEvents.DiceUpgraded -= Hide;
    }

    private void Hide()
    {
        foreach (SideObj s in sideobjects)
        {
            if (s.enbld.activeSelf)
            {
                s.enbld.SetActive(false);
                s.gameObject.SetActive(false);
            }
        }
    }

    [Button]
    public void GetSides()
    {
        shopSides.Clear();
        List<SideData> currSides = new List<SideData>(GameManager.Instance.availableSides);
        for (int i = 0; i < 3; i++)
        {
            int random = UnityEngine.Random.Range(0, currSides.Count);
            shopSides.Add(currSides[random]);
            currSides.RemoveAt(random);
        }

        foreach (Transform t in parent)
        {
            t.gameObject.SetActive(false);
        }

        for (int i = 0; i < shopSides.Count; i++)
        {
            sideobjects[i].gameObject.SetActive(true);
            sideobjects[i].Setup(shopSides[i], i);
        }
    }
}