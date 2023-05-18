using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Function for the UI to display an Action Node's available actions and details for selection
/// </summary>
public class ActionButton : MonoBehaviour
{
    private AttackAction storedAction;

    public AttackAction StoredAction { get => storedAction; set => storedAction = value; }

    

    [SerializeField] Text moveNameText;
    [SerializeField] Image attributeImage;
    [SerializeField] Text moveAttrText;
    [SerializeField] Text movePotencyText;
    [SerializeField] Text moveCostText;
    [SerializeField] Text moveDescText;

    [SerializeField] Sprite Physical_Icon;
    [SerializeField] Sprite Magik_Icon;
    [SerializeField] Sprite Tech_Icon;


    public void Initialize(AttackAction action)
    {
        storedAction = action;

        moveNameText.text = storedAction.moveName;

        #region Assign Icon
        if (storedAction.attribute == ActionAttribute.Physical)
        {
            attributeImage.sprite = Physical_Icon;
        }
        else if (storedAction.attribute == ActionAttribute.Magik)
        {
            attributeImage.sprite = Magik_Icon;
        }
        else
        {
            attributeImage.sprite = Tech_Icon;
        }
        #endregion

        #region Assign Color
        if (storedAction.attribute == ActionAttribute.Magik)
        {
            moveAttrText.text = $"<color=#bd49b9>{ storedAction.attribute.ToString()}</color>";
        }
        else if (action.attribute == ActionAttribute.Tech)
        {
            moveAttrText.text = $"<color=#4cb2ad>{ storedAction.attribute.ToString()}</color>";
        }
        else //Physical
        {
            moveAttrText.text = $"<color=#b8904b>{ storedAction.attribute.ToString()}</color>";
        }
        #endregion


        movePotencyText.text = "Potency: " + storedAction.potency.ToString();
        moveCostText.text = "Mana Cost: " + storedAction.manaCost.ToString();
        moveDescText.text = storedAction.description;

        

    }

    public void GivePlayerAction(MoveList moveList)
    {
        moveList.moveList.Add(storedAction);
    }

    


}
