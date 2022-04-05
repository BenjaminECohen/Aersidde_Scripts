using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{

    public PlayerState(BattleSystem fightSystem) : base(fightSystem)
    {

    }


    public override IEnumerator Start()
    {
        FightSystem.player.StartTick();
        //Show Player UI
        FightSystem.playerActionMenu.SetActive(true);
        return base.Start();

    }

    public override IEnumerator End()
    {
        
        FightSystem.player.EndTick();
        FightSystem.playerActionMenu.SetActive(false);
        FightSystem.playerMoveUI.SetActive(false);
        FightSystem.isPlayerTurn = false;
        yield return new WaitForSeconds(1.5f);
        FightSystem.NextState();
    }
}
