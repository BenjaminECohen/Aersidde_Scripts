﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStatus : EntityStatus
{
    public EnemyAI enemyAIPattern;


    public void EnemyAwakeSetup(EntityAnimController targetEnemy, EnemyStats enemyStats)
    {
        animController = targetEnemy;
        if (enemyStats.isRandomStats) //If a fodder enemy, randomize the stats
        {
            enemyStats.RandomizeFodderStats();
        }
        stats = enemyStats;
        stats.currentHealth = stats.MaxHealth; // Make sure fully healed
        enemyAIPattern = enemyStats.enemyAI;
        targetEnemy.gameObject.SetActive(true);   
        weakness = enemyStats.weakness;
        
        
    }



    public int DecideAction()
    {
        return enemyAIPattern.GetAIDecision(this);
    }

    
}
