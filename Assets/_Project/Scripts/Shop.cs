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
    public int sidesInShopAmount = 3;

    private void Start()
    {
        GetSides();
    }

    private void OnEnable()
    {
        GlobalEvents.OnDiceUpgraded += Hide;
    }
    private void OnDisable()
    {
        GlobalEvents.OnDiceUpgraded -= Hide;
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

    public void Refresh()
    {
        GlobalEvents.OnRefreshShop?.Invoke();
        GetSides();
    }

    [Button]
    public void GetSides()
    {
        shopSides.Clear();
        List<SideData> currSides = new List<SideData>(GameManager.Instance.availableSides);
        for (int i = 0; i < sidesInShopAmount; i++)
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