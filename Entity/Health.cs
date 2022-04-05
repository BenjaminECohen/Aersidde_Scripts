using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth = 100;

    // Start is called before the first frame update
    public void AssignValues(int maxHealth, int currHealth)
    {
        MaxHealth = maxHealth;
        currentHealth = currHealth;
    }

    public int DealDamage(int value)
    {
        currentHealth -= value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        Debug.Log($"<color=red>{value}</color> Dmg dealt to {this.gameObject.name}\n{this.gameObject.name} has {currentHealth} hp left.");        
        return currentHealth;
    }

    public int Heal(int value)
    {
        currentHealth += value;
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        Debug.Log($"<color=green>{value}</color> health healed to {this.gameObject.name}\nHealth now at {currentHealth} / {MaxHealth}");
        return currentHealth;
    }

    public bool checkIfGreaterThanPercent(float greaterThanDecimal, bool equalTo)
    {
        if (equalTo)
        {
            if ((float)currentHealth / (float)MaxHealth >= greaterThanDecimal)
            {
                return true;
            }
        }
        else
        {
            if ((float)currentHealth / (float)MaxHealth > greaterThanDecimal)
            {
                return true;
            }
        }
        
        return false;
    }


}
