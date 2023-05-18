using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI for the Fodder enemies
/// </summary>

[CreateAssetMenu(menuName = "EnemyAI/Fodder")]
public class Fodder_AI : EnemyAI
{
    public override int GetAIDecision(EnemyStatus enemyStatus)
    {
        return Random.Range(0, 3);
    }
    public override void ResetValues()
    {       
        base.ResetValues();
    }
}
