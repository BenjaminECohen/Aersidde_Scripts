using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI for an enemy who has 4 specific moves that play in rotation
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/EnemyType2")]
public class EnemyType2 : EnemyAI
{
    int attackIndex = 0;

    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        if (attackIndex == 0)
        {
            attackIndex++;
            //Attack with a basic physical attack (Med Dmg)
            return 1;
        }
        if (attackIndex == 1)
        {
            attackIndex++;
            //Buff next move by 20%
            return 2;
        }
        if (attackIndex == 2)
        {
            attackIndex++;
            //Attack with a Tech Attack (Med Dmg)
            return 3;
        }
        else
        {
            //Reset index
            attackIndex = 0;
            //Attack with a phy attack (Low dmg)
            return 4;
        }
        
    }
}
