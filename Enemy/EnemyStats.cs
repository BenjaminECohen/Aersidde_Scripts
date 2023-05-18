using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stats and methods for enemy specific stats
/// </summary>

[CreateAssetMenu]
public class EnemyStats : EntityStats
{
    [Header("Enemy Stats")]
    public EnemyAI enemyAI;
    public BattleSystem.EnemyRig enemyRigVariation = BattleSystem.EnemyRig.BOSS;

    public bool isRandomStats = false;

    /// <summary>
    /// Only use for fodder 
    /// </summary>
    public void RandomizeFodderStats()
    {
        Speed = Random.Range(1, 11);
        MaxHealth = Random.Range(100, 136);
        weakness = (ActionAttribute)Random.Range(0, 3);

    }

    
    
}
