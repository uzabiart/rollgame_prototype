using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GenericButton : MonoBehaviour
{
    string animId;

    private void Start()
    {
        animId = gameObject.GetInstanceID().ToString();
    }

    public void OnClick()
    {
        DOTween.Kill(animId, true);
        transform.DOPunchScale(Vector3.one * 0.2f, 0.2f).SetId(animId);
    }
}