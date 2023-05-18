using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to manage the functionality and display of the player action list
/// </summary>

public class PlayerMoveListManager : MonoBehaviour
{
    [Header("Attack List UI")]
    public GameObject MoveUI;
    public List<Button> moveButtons = new List<Button>();
    [Space(10)]
    public Text moveName;
    public Text moveAttribute;
    public Text movePotency;
    public Text moveCost;
    public Text moveDescription;
    public PlayerStatus player;

    int currentMoveIndex;


    public void UnlistButtons()
    {
        foreach(Button button in moveButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    public void GenerateButtonList(PlayerStatus player) //Setup all the necessary buttons and assign the correct info
    {
        int i = 0;
        foreach(AttackAction act in player.attackActions)
        {
            moveButtons[i].GetComponentInChildren<Text>().text = act.name; //Get ui text and assign action name
            moveButtons[i].onClick.AddListener(() => ShowAttackInfo(act) ); //Assign listener to button to with data for the necessary stats
            i++;
        }
        for (int j = i; j < moveButtons.Count; j++)
        {
            moveButtons[j].GetComponentInChildren<Text>().text = "Empty";
        }

        //Display the first move of the players action list at the start
        currentMoveIndex = 0;
        this.player = player;
        ShowAttackInfo(player.attackActions[0]);

    }

    //Orange Phys: #b8904b
    //Cyan Tech: #4cb2ad
    //Magenta Magik: #bd49b9

    public void ShowAttackInfo(AttackAction action)
    {
        currentMoveIndex = player.attackActions.IndexOf(action);
        moveName.text = action.moveName;

        if (action.attribute == ActionAttribute.Magik)
        {
            moveAttribute.text = $"Attribute: <color=#bd49b9>{ action.attribute.ToString()}</color>";
        }
        else if (action.attribute == ActionAttribute.Tech) 
        {
            moveAttribute.text = $"Attribute: <color=#4cb2ad>{ action.attribute.ToString()}</color>";
        }
        else //Physical
        {
            moveAttribute.text = $"Attribute: <color=#b8904b>{ action.attribute.ToString()}</color>";
        }

        
        movePotency.text = "Potency: " + action.potency.ToString();
        moveCost.text = "Mana Cost: " + action.manaCost.ToString();
        moveDescription.text = action.description;
    }

    public int getCurrentMoveIndex()
    {
        return currentMoveIndex;
    }

}
