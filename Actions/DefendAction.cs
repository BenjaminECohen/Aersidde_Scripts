using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DefendAction : Action
{

    [Header("Defensive Variables")]
    public float defenseDecimalValue = 0.5f;
    public int duration = 1;


    public override int Execute(EntityStatus actor, EntityStatus target)
    {
        actor.defenseModifiers.Add(ModifierConstruct.CreateModifier(defenseDecimalValue, duration));
        Debug.Log($"Defense up for {actor.name} at {defenseDecimalValue} for {duration}");
        return base.Execute(actor, target);
    }
}
