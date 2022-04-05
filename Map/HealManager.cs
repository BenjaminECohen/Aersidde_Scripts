using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealManager : MonoBehaviour
{
    public Text infoText;

    public void DisplayInfo(EntityStats stats)
    {
        float percentage = ((float)stats.currentHealth / (float)stats.MaxHealth) * 100f;

        infoText.text = "Current Integrity: " + percentage.ToString("F1") + "%";
    }

    public void HealEntity(EntityStats stats)
    {
        stats.currentHealth += Mathf.RoundToInt((float)stats.MaxHealth / 2f);
        if (stats.currentHealth > stats.MaxHealth)
        {
            stats.currentHealth = stats.MaxHealth;
        }
    }

    public void StoreHeal(EntityStats stats)
    {
        stats.storedHeals++;
    }
}
