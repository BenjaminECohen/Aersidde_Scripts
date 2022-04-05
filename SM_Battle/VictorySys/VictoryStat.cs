using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryStat : MonoBehaviour
{
    public Text statText;
    public Button topButton;
    public Button botButton;
    public IntegerVariable increaseValue;

    VictorySys victorySys;

    private void Start()
    {
        victorySys = FindObjectOfType<VictorySys>();
    }

    public void IncreaseStat()
    {

        victorySys.setTopButtonInteractable(false); //Turn off all tops, no more increasing
        victorySys.setBotButtonInteractable(false); //Turn off all the bottoms

        botButton.interactable = true; //Allow only current stat bottom button to be activated

        statText.text = (int.Parse(statText.text) + increaseValue.value).ToString();

        victorySys.SetConfirmInteractable(true);

    }

    public void DecreaseStat()
    {
        victorySys.setTopButtonInteractable(true); //Turn on all the tops, you may increase any one
        victorySys.setBotButtonInteractable(false); //Turn off all the bottoms


        statText.text = (int.Parse(statText.text) - increaseValue.value).ToString();

        victorySys.SetConfirmInteractable(false);
    }

}
