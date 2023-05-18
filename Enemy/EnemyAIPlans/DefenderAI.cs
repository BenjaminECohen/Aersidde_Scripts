using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI for the Defender Enemy Miniboss
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/Defender")]
public class DefenderAI : EnemyAI
{
    public int turnIndex = 0;

    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        Debug.Log("Defender Attack");
        if (turnIndex == 0)
        {
            turnIndex++;
            return 0;
        }
        else
        {
            turnIndex = 0;
            return 1;
        }
        
    }

    public override void ResetValues()
    {
        turnIndex = 0;
        base.ResetValues();
    }
}
