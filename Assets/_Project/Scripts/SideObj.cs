using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SideObj : MonoBehaviour
{
    public Image icon;
    public Transform icons;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI weight;
    public SideData data;
    public int id;

    public GameObject enbld;

    private void OnEnable()
    {
        GlobalEvents.OnUpdateView += UpdateView;
    }
    private void OnDisable()
    {
        GlobalEvents.OnUpdateView -= UpdateView;
    }

    public void UpdateView()
    {
        if (enbld != null)
            if (GameManager.Instance.currentSide == data)
                enbld.SetActive(true);
            else
                enbld.SetActive(false);

        if (data == null) return;
        if (GameManager.Instance.showWeight)
        {
            weight.text = data.weight.ToString();
            weight.transform.parent.gameObject.SetActive(true);
        }
        else
            weight.transform.parent.gameObject.SetActive(false);
    }

    public void Setup(SideData data, int id = 0)
    {
        this.data = data;
        this.id = id;
        desc.text = data.description;

        if (data.icons.Length > 0)
        {
            icon.gameObject.SetActive(false);
            icons.gameObject.SetActive(true);
            int i = 0;
            foreach (Transform t in icons)
            {
                t.gameObject.SetActive(false);
            }
            foreach (Sprite s in data.icons)
            {
                icons.GetChild(i).gameObject.SetActive(true);
                icons.GetChild(i).GetComponent<Image>().sprite = s;
                i++;
            }
        }
        else
        {
            icon.sprite = data.icon;
            icon.gameObject.SetActive(true);
            icons.gameObject.SetActive(false);
        }

        UpdateView();
    }

    public void OnClick()
    {
        GlobalEvents.OnSideClick?.Invoke(this);
    }
}