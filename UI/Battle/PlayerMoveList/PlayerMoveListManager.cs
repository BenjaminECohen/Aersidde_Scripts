using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UnlistButtons()
    {
        foreach(Button button in moveButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    public void GenerateButtonList(PlayerStatus player)
    {
        int i = 0;
        foreach(AttackAction act in player.attackActions)
        {
            moveButtons[i].GetComponentInChildren<Text>().text = act.name;
            moveButtons[i].onClick.AddListener(() => ShowAttackInfo(act) );
            i++;
        }
        for (int j = i; j < moveButtons.Count; j++)
        {
            moveButtons[j].GetComponentInChildren<Text>().text = "Empty";
        }
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
