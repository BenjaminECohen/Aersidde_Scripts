using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    public GameObject damageDisplay;
    public Text effectiveText;
    public Text damageText;
    public Animator anim;

    [Header("Colors")]
    string physical = "#e8b04f";
    string tech = "#4fe8e0";
    string magik = "#e84fe3";

    private void Start()
    {
        damageDisplay.SetActive(false);
    }

    public void DisplayDmg(int damageVal, ActionAttribute attribute, bool crit, bool effective)
    {


        damageText.text = damageVal.ToString();
        effectiveText.text = "Effective!";

        if (crit)
        {
            damageText.text += "!";
        }
        if (effective)
        {
            damageText.text += "!";
        }

        
        if (attribute == ActionAttribute.Magik)
        {
            damageText.text = $"<color={magik}>{damageText.text}</color>";
            effectiveText.text = $"<color={magik}>{effectiveText.text}</color>";
            Debug.Log("Magic attack");
        }
        else if (attribute == ActionAttribute.Tech)
        {
            damageText.text = $"<color={tech}>{damageText.text}</color>";
            effectiveText.text = $"<color={tech}>{effectiveText.text}</color>";
            Debug.Log("Tech attack");
        }
        else
        {
            damageText.text = $"<color={physical}>{damageText.text}</color>";
            effectiveText.text = $"<color={physical}>{effectiveText.text}</color>";
            Debug.Log("PHY attack");
        }

        effectiveText.gameObject.SetActive(effective);

        anim.SetTrigger("play");

        
    }
}
