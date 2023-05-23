using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDice : MonoBehaviour
{
    public SideObj changeObj;

    private void OnEnable()
    {
        GlobalEvents.OnShowDice += ShowEdit;
        GlobalEvents.OnDiceUpgraded += Hide;
    }
    private void OnDisable()
    {
        GlobalEvents.OnShowDice -= ShowEdit;
        GlobalEvents.OnDiceUpgraded -= Hide;
    }

    private void ShowEdit()
    {
        GameManager.Instance.ChangeGameState(GameStates.Upgrade);

        if (GameManager.Instance.currentSide == null)
            transform.GetChild(0).gameObject.SetActive(true);
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);

            changeObj.Setup(GameManager.Instance.currentSide);
        }
    }
    public void Hide()
    {
        GameManager.Instance.ChangeGameState(GameStates.Gameplay);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
