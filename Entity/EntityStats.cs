using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityStats : ScriptableObject
{
    public ActionAttribute weakness = ActionAttribute.NONE;

    [Header("Information")]
    
    public int currentHealth;

    
    public int currentMana;

    
   

    public MoveList entityMoveSet;

    public int storedHeals;
    

    [Header("Stats")]
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] private int maxMana = 100;
    public int MaxMana { get => maxMana; set => maxMana = value; }

    [SerializeField] private int strength = 50;
    public int Strength { get => strength; set => strength = value; }

    [SerializeField] private int speed = 2;
    public int Speed { get => speed; set => speed = value; }



    [Header("ResetBaseStats: For Player")]
    public int baseStrength = 50;
    public int baseSpeed = 2;
    public int baseMaxHealth = 100;
    public int baseMaxMana = 100;

    public void ResetStats()
    {
        //Return to base values
        Strength = baseStrength;
        Speed = baseSpeed;
        MaxHealth = baseMaxHealth;
        MaxMana = baseMaxMana;


        //Reset all other data
        currentHealth = maxHealth;
        currentMana = maxMana;
        entityMoveSet.ResetList();
        storedHeals = 0;

    }
    
}
