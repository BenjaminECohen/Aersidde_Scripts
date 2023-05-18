using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to handle the functions of the health UI
/// </summary>


public class HealthUI : MonoBehaviour
{
    public Image fillbar1; //Front
    public Image fillbar2; //Lagged
    public Text healthAmountDisplay;
    public Health targetHealth;

    public float lastFill;

    public void Init(Health target) //Initialize the starting values for health functions based on the entity stats at the start of battle
    {
        targetHealth = target;
        lastFill = (float) target.currentHealth / (float)target.MaxHealth;
        fillbar1.fillAmount = lastFill;
        fillbar2.fillAmount = lastFill;
        healthAmountDisplay.text = $"{targetHealth.currentHealth}/{targetHealth.MaxHealth}";
    }

    [Header("HealthVariables")]
    float frontDuration = .5f;
    float timestamp1;
    float waitDuration = 0.5f;
    float lagDuration = .75f;
    float timestamp2;
    float timestampHeal;

    float distanceDifference;

    float t1 = 0;
    float t2 = 0;

    [SerializeField] bool adjust = false;
    [SerializeField] bool secondAdjust = false;
    bool healAdjust = false;

    private void Update()
    {
       if (adjust) //First health bar adjustment
        {
            t1 = (Time.time - timestamp1) / frontDuration;
            if (t1 > 1f)
            {
                t1 = 1f;
                fillbar1.fillAmount = lastFill - (t1 * distanceDifference);
                adjust = false;
                t1 = 0;
                healthAmountDisplay.text = $"{targetHealth.currentHealth}/{targetHealth.MaxHealth}";
            }
            else
            {
                fillbar1.fillAmount = lastFill - (t1 * distanceDifference);
                healthAmountDisplay.text = $"{Mathf.FloorToInt((float)targetHealth.MaxHealth * fillbar1.fillAmount)}/{targetHealth.MaxHealth}";
            }
        }
       if (secondAdjust) //Second healthbar that lags behind to give an interesting visual animation to health loss
        {
            t2 = (Time.time - timestamp2) / lagDuration;
            if (t2 > 1f)
            {
                t2 = 1f;
                fillbar2.fillAmount = lastFill - (t2 * distanceDifference);
                secondAdjust = false;
                t2 = 0;
                lastFill = fillbar2.fillAmount;
                //Debug.Log($"Fillbar amount: {lastFill}");
            }
            else
            {
                fillbar2.fillAmount = lastFill - (t2 * distanceDifference);
            }
        }
        #region Healing
        if (healAdjust) //Method for when an entity is being healed
        {
            t1 = (Time.time - timestampHeal) / frontDuration;
            if (t1 > 1f)
            {
                t1 = 1f;
                fillbar1.fillAmount = lastFill + (t1 * distanceDifference);
                fillbar2.fillAmount = lastFill + (t1 * distanceDifference);
                lastFill = fillbar2.fillAmount;
                healAdjust = false;
                t1 = 0;
                healthAmountDisplay.text = $"{targetHealth.currentHealth}/{targetHealth.MaxHealth}";
            }
            else
            {
                fillbar1.fillAmount = lastFill + (t1 * distanceDifference);
                healthAmountDisplay.text = $"{Mathf.FloorToInt((float)targetHealth.MaxHealth * fillbar1.fillAmount)}/{targetHealth.MaxHealth}";
            }
        }
        #endregion
    }

    public void adjustHeal() //Trigger to start adjustment on health when healed
    {
        distanceDifference = ((float)targetHealth.currentHealth / (float)targetHealth.MaxHealth) - lastFill;
        Debug.Log($"Dist Dif: {distanceDifference}");
        timestampHeal = Time.time;
        healAdjust = true;
    }

    
    public void adjustHealth() //Trigger to start adjustment on health when damaged
    {
        distanceDifference = lastFill - ((float)targetHealth.currentHealth / (float)targetHealth.MaxHealth);
        //Debug.Log($"Dist Dif: {distanceDifference}");
        timestamp1 = Time.time;
        adjust = true;
        StartCoroutine(waitForSecondAdjust());

    }

    IEnumerator waitForSecondAdjust() 
    {
        yield return new WaitForSeconds(waitDuration);
        timestamp2 = Time.time;
        secondAdjust = true;
    }


    

}
