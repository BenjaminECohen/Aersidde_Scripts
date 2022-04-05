using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    public EnemyState(BattleSystem fightSystem) : base(fightSystem)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"<color=cyan>Starting state: {this}</color>");
        FightSystem.enemy.StartTick();
        yield return new WaitForSeconds(1f);
        int actionIndex = FightSystem.enemy.DecideAction();

        
        //COROUTINE 2
        yield return FightSystem.Attack(FightSystem.enemy, FightSystem.player, actionIndex);
        
        
    }

    public override IEnumerator End()
    {
        FightSystem.enemy.EndTick();
        FightSystem.isPlayerTurn = true;
        /*
        if (FightSystem.player.entityHealth.currentHealth == 0)
        {
            FightSystem.PlayerDeath();
        }
        else
        {
            FightSystem.isPlayerTurn = true;
            FightSystem.NextState();
        }*/
        return base.End();
    }

    /*
    public int DecideAction()
    {
        //Determines based on EnemyFight Logic
        
        int remainingHealth = FightSystem.enemy.attackActions[actionIndex].Execute(FightSystem.enemy, FightSystem.player);
        FightSystem.playerHealthUI.adjustHealth();
        return remainingHealth;
    
    }*/
}
