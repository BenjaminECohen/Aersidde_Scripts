using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackAction : Action
{
    [Header("Offensive Variables")]
    public ActionAttribute attribute = ActionAttribute.Physical;
    public int potency = 100;
    public int manaCost = 0;

    [Header("Change to Modifier")]
    public bool isModifier = false;
    [Tooltip("Else target enemy")]
    public bool targetSelf = true;
    public int duration = 3;
    [Tooltip("False = Defensive")]
    public bool isOffensive = true;
    public float decimalValue = 0.2f;


    [Header("Appearance")]
    public string moveName;
    [TextArea(1, 4)]
    public string description;

    [Header("Effect")]
    public int atkAnimation = 1;

    [Tooltip("atk anim 1: .6 sec\n" + " atk anim 2: 1 sec\n" + "atk anim 3: 0.6 sec")]
    public float effectDelay = 0.6f;
    public int yOffset = 0;


    




    public override int Execute(EntityStatus actor, EntityStatus target)
    {
        actor.entityMana.useMana(manaCost);

        if (isModifier) // Add Modifier
        {
            EntityStatus modTarget;

            Modifier<float, int> mod = new Modifier<float, int>();
            mod.duration = duration;
            mod.value = decimalValue;

            Debug.Log("Add Modifier");
            if (targetSelf)
            {
                modTarget = actor;
            }
            else
            {
                modTarget = target;
            }

            if (isOffensive)
            {
                mod.duration++; //Add an extra turn so you have correct duration AFTER this turn
                modTarget.attackModifiers.Add(mod);
                Debug.Log($"ATK Mod {mod.value * 100}% added to {modTarget} for {mod.duration - 1} turns");
            }
            else
            {
                modTarget.defenseModifiers.Add(mod);
                Debug.Log($"DEF Mod {mod.value * 100}% added to {modTarget} for {mod.duration} turns");
            }
            return target.entityHealth.currentHealth;


        }
        else //Just an attack
        {
            Debug.Log($"Attack Action {moveName}");
            int remainingHealth = target.entityHealth.DealDamage(CalculateDamage(actor, target));
            return remainingHealth;
        }

        
    }

    int CalculateDamage(EntityStatus actor, EntityStatus target)
    {
        DamageDisplay dmgDisplay = FindObjectOfType<DamageDisplay>();

        int finalDamage;

        int actorAttackStat = actor.stats.Strength;
        float modBonus = 0f;
        //Get Attack Bonuses
        foreach (Modifier<float, int> mod in actor.attackModifiers)
        {
            modBonus += mod.value;
        }

        float baseDamage = ((float)actorAttackStat + ((float)actorAttackStat * modBonus)) * ((float)potency / 100f);

        //Check for weakness IF T, then increase base Damage by 0.5f;
        bool effective = false;
        if (target.weakness != ActionAttribute.NONE && target.weakness == attribute)
        {
            Debug.Log("Target WEAK to " + attribute);
            baseDamage *= 1.5f;
            effective = true;
        }

        bool crit = false;
        if (DetermineCrit())
        {
            Debug.Log($"<color=yellow>CRIT!!!</color>");
            baseDamage *= 2f;
            crit = true;
        }

        //Calculate Enemy Defense
        float targetDefenseBonus = 0;
        foreach (Modifier<float, int> mod in target.defenseModifiers)
        {
            targetDefenseBonus += mod.value;
        }
        if (targetDefenseBonus >= 1) //Makes sure target defense never exceeds 100%
        {
            targetDefenseBonus = 1f;
        }

        finalDamage = Mathf.FloorToInt(baseDamage - (baseDamage * targetDefenseBonus));

        if (actor != FindObjectOfType<EnemyStatus>())
        {
            dmgDisplay.DisplayDmg(finalDamage, attribute, crit, effective);
        }
        


        return finalDamage;

    }

    bool DetermineCrit()
    {
        float value = Random.Range(0f, 1f);
        if (value <= 0.15f)
        {
            return true;
        }

        return false;
    }

    
    
}
