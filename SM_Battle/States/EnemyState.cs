using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy State specific Start and End functionalities
/// </summary>

public class EnemyState : State
{
    public EnemyState(BattleSystem fightSystem) : base(fightSystem)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log($"<color=cyan>Starting state: {this}</color>");
        FightSystem.enemy.StartTick(); //Decrease certain modifiers duration
        yield return new WaitForSeconds(1f);
        int actionIndex = FightSystem.enemy.DecideAction();

        
        //COROUTINE 2
        yield return FightSystem.Attack(FightSystem.enemy, FightSystem.player, actionIndex);
        
        
    }

    public override IEnumerator End()
    {
        FightSystem.enemy.EndTick(); //Decrease certain modifiers duration
        FightSystem.isPlayerTurn = true;
        
        return base.End();
    }

}
