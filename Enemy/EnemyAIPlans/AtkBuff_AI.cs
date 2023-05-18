using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI for the Miniboss that buffs the strength of it's attacks
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/ATK_Buffer")]
public class AtkBuff_AI : EnemyAI
{
    int turnIndex = 0;

    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        if (turnIndex == 0)
        {
            turnIndex++;
            return 0;
        }
        else if (turnIndex == 1)
        {
            turnIndex++;
            return 1;
        }
        else
        {
            turnIndex = 0;
            return 2;
        }
    }

    public override void ResetValues()
    {
        turnIndex = 0;
        base.ResetValues();
    }
}
