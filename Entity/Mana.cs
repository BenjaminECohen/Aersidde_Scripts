using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{

    public float MaxMana = 100;
    float currentMana;

    public float CurrentMana { get => currentMana; private set => currentMana = value; }

    // Start is called before the first frame update
    public void AssignValues(int maxMana)
    {
        MaxMana = maxMana;
        
    }

    public void ResetMana()
    {
        CurrentMana = MaxMana;
    }

    public void useMana(int value)
    {
        CurrentMana -= value;
    }

    public void gainMana(int value)
    {
        CurrentMana += value;
    }



    
    
}
