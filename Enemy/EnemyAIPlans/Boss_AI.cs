using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI for the Game Boss
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/Boss")]
public class Boss_AI : EnemyAI
{
    int turnIndex = 0;
    int turnsTillBigAtk;

    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        if (turnIndex == 0) //Poke and set
        {
            turnIndex++;
            turnsTillBigAtk = Random.Range(2, 4);
            return 0;
        }
        if (turnIndex < turnsTillBigAtk) //Poke
        {
            turnIndex++;
            return 0;
        }
        else if (turnIndex == turnsTillBigAtk) //Buff self
        {
            turnIndex++;
            return 1;
        } 
        else //Unleash big attack
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
