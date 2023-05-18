using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Individual class to handle a single stats functionality in the victory screen
/// </summary>

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

        victorySys.setTopButtonInteractable(false); //Turn off all stat increase buttons, no more increasing
        victorySys.setBotButtonInteractable(false); //Turn off all the stat decrease buttons

        botButton.interactable = true; //Turn on the decrease button for this stat only

        statText.text = (int.Parse(statText.text) + increaseValue.value).ToString();

        victorySys.SetConfirmInteractable(true);

    }

    public void DecreaseStat()
    {
        victorySys.setTopButtonInteractable(true); //Turn on all the stat increase buttons, you may increase any one
        victorySys.setBotButtonInteractable(false); //Turn off all the stat decrease buttons


        statText.text = (int.Parse(statText.text) - increaseValue.value).ToString();

        victorySys.SetConfirmInteractable(false);
    }

}
