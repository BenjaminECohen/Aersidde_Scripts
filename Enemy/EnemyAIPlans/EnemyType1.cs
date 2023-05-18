using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic AI for an enemy with 3 attacks based on health values
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/EnemyType1")]
public class EnemyType1 : EnemyAI
{
    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        

        if(enemyStatus.entityHealth.checkIfGreaterThanPercent(0.9f, true)) //Health greater than 90%
        {
            return 1;
        }
        else if (enemyStatus.entityHealth.checkIfGreaterThanPercent(0.50f, true)) //Health greater than or equal to 50%
        {
            return 0;
        }
        else
        {
            return 2;
        }
    }
}
