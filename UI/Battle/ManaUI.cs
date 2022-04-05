using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Image fillbar1; //Front
    public Image fillbar2; //Lagged
    public Text manaAmountDisplay;
    public Mana targetMana;

    public float lastFill;

    

    public void Init(Mana target)
    {
        targetMana = target;
        lastFill = (float)target.CurrentMana / (float)target.MaxMana;
        fillbar1.fillAmount = lastFill;
        manaAmountDisplay.text = $"{targetMana.CurrentMana}/{targetMana.MaxMana}";
    }

    [Header("HealthVariables")]
    float frontDuration = .5f;
    float timestamp1;
    float waitDuration = 0.5f;
    float lagDuration = .75f;
    float timestamp2;

    float distanceDifference;

    float t1 = 0;
    float t2 = 0;

    [SerializeField] bool adjust = false;
    [SerializeField] bool secondAdjust = false;

    private void Update()
    {
        if (adjust)
        {
            t1 = (Time.time - timestamp1) / frontDuration;
            if (t1 > 1f)
            {
                t1 = 1f;
                fillbar1.fillAmount = lastFill - (t1 * distanceDifference);
                adjust = false;
                t1 = 0;

                manaAmountDisplay.text = $"{targetMana.CurrentMana}/{targetMana.MaxMana}";

            }
            else
            {
                fillbar1.fillAmount = lastFill - (t1 * distanceDifference);
                manaAmountDisplay.text = $"{Mathf.FloorToInt((float)targetMana.MaxMana * fillbar1.fillAmount)}/{targetMana.MaxMana}";
            }
        }
        if (secondAdjust)
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
    }



    public void adjustMana()
    {
        distanceDifference = lastFill - ((float)targetMana.CurrentMana / (float)targetMana.MaxMana);
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
