using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using TMPro;

public class Dice : MonoBehaviour
{
    public Side d1 = new Side(new Vector3(90, 0, 0), 0);
    public Side d2 = new Side(new Vector3(180, 0, 0), 1);
    public Side d3 = new Side(new Vector3(-90, 0, 0), 2);
    public Side d4 = new Side(new Vector3(0, 0, 90), 3);
    public Side d5 = new Side(new Vector3(0, 0, -90), 4);
    public Side d6 = new Side(new Vector3(0, 0, 0), 5);

    public List<Side> sides = new List<Side>();

    public TextMeshProUGUI description;
    public SideData defaultData;

    private void OnEnable()
    {
        GlobalEvents.OnRoll += Roll;
        GlobalEvents.UpdateView += UpdateView;
    }
    private void OnDisable()
    {
        GlobalEvents.OnRoll -= Roll;
        GlobalEvents.UpdateView -= UpdateView;
    }

    private void UpdateView()
    {
        Debug.Log("Update view");
    }

    private void Start()
    {
        sides = new List<Side>()
        {
            d1,d2,d3,d4,d5,d6
        };
        SetupDefault();
    }

    private void SetupDefault()
    {
        foreach (Side s in sides)
        {
            s.UpdateSide(defaultData);
        }
    }

    public void SetupSide(SideData newSide, int id)
    {
        sides[id].UpdateSide(newSide);

    }

    [Button]
    public void Roll()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        int random = UnityEngine.Random.Range(0, sides.Count);
        Side randomSide = sides[random];
        transform.GetChild(0).DORotate(randomSide.rot, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).DOPunchScale(Vector3.one * 0.1f, 0.1f);
            transform.GetChild(1).DOPunchScale(Vector3.one * 0.001f, 0.1f);
            description.text = randomSide.data.description;
        });
    }

    [Button]
    public void Edit()
    {
        GlobalData.CurrentDice = this;
        GlobalEvents.OnShowDice?.Invoke();
    }
}

[System.Serializable]
public class Side
{
    public Side(Vector3 rot, int id)
    {
        this.id = id;
        this.rot = rot;
    }

    public int id;
    public Vector3 rot;
    public SideData data;
    public Image icon;

    public void UpdateSide(SideData newData)
    {
        data = newData;
        icon.sprite = data.icon;
    }
}