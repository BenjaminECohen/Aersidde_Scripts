using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// AI for the first enemy encountered in the game
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/FirstEncounter")]
public class FirstAI : EnemyAI
{
    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        return base.GetAIDecision(enemyStatus);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
