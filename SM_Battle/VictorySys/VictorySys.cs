using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that controls the functions of the victory screen UI and the stat increase functionality
/// </summary>

public class VictorySys : MonoBehaviour
{
    public EntityStats playerStats;
    public GameObject victoryScreen;
    BattleSystem battleSys;

    [Header("Text Boxes")]
    public Text speedBox;
    public Text strengthBox;
    public Text healthBox;
    public Text manaBox;

    [Header("Buttons")]
    public Button confirmButton;
    public List<Button> topButtons;
    public List<Button> botButtons;

    public void Start()
    {
        battleSys = FindObjectOfType<BattleSystem>();
    }

    public void ConfirmAllocation() //Set the player stats according to the values in the victory screen
    {
        playerStats.Speed = int.Parse(speedBox.text);
        playerStats.Strength = int.Parse(strengthBox.text);
        playerStats.MaxHealth = int.Parse(healthBox.text);
        playerStats.MaxMana = int.Parse(manaBox.text);

        SceneManager.LoadScene(battleSys.mapSceneIndex);
    }


    public void Init() //Initialize the victory screen UI state and details
    {
        SetConfirmInteractable(false);
        setTopButtonInteractable(true);
        setBotButtonInteractable(false);
        speedBox.text = playerStats.Speed.ToString();
        strengthBox.text = playerStats.Strength.ToString();
        healthBox.text = playerStats.MaxHealth.ToString();
        manaBox.text = playerStats.MaxMana.ToString();
        victoryScreen.SetActive(true);
    }

    public void SetConfirmInteractable(bool val)
    {
        confirmButton.interactable = val;
    }

    public void setBotButtonInteractable(bool val)
    {
        foreach(Button b in botButtons)
        {
            b.interactable = val;
        }
    }
    public void setTopButtonInteractable(bool val)
    {
        foreach (Button b in topButtons)
        {
            b.interactable = val;
        }
    }


}
