using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SideObj : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI desc;
    public SideData data;
    public int id;

    public GameObject enbld;

    private void OnEnable()
    {
        GlobalEvents.UpdateView += UpdateView;
    }
    private void OnDisable()
    {
        GlobalEvents.UpdateView -= UpdateView;
    }

    public void UpdateView()
    {
        if (enbld != null)
            if (GameManager.Instance.currentSide == data)
                enbld.SetActive(true);
            else
                enbld.SetActive(false);
    }

    public void Setup(SideData data, int id = 0)
    {
        this.data = data;
        this.id = id;
        icon.sprite = data.icon;
        desc.text = data.description;
    }

    public void OnClick()
    {
        GlobalEvents.OnSideClick?.Invoke(this);
    }
}