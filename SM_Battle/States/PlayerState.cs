using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player State specific Start and End functionalities
/// </summary>

public class PlayerState : State
{

    public PlayerState(BattleSystem fightSystem) : base(fightSystem)
    {

    }


    public override IEnumerator Start()
    {
        FightSystem.player.StartTick(); //Decrease certain modifiers duration
        //Show Player UI
        FightSystem.playerActionMenu.SetActive(true);
        return base.Start();

    }

    public override IEnumerator End()
    {
        
        FightSystem.player.EndTick(); //Decrease certain modifiers duration
        FightSystem.playerActionMenu.SetActive(false);
        FightSystem.playerMoveUI.SetActive(false);
        FightSystem.isPlayerTurn = false;
        yield return new WaitForSeconds(1.5f);
        FightSystem.NextState();
    }
}
