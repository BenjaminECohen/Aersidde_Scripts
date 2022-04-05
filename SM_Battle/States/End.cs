using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : State
{
    public End(BattleSystem fightSystem) : base(fightSystem)
    {

    }

    public override IEnumerator Start()
    {
        FightSystem.playerActionMenu.SetActive(false);
        if (FightSystem.player.entityHealth.currentHealth == 0)
        {
            Debug.Log("Player Loses");
            FightSystem.player.animController.PlayDeadAnim();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(FightSystem.mainMenuIndex);
            //Reset Player Stats at main menu START
        }
        else
        {
            Debug.Log("Player Wins");

            FightSystem.player.stats.currentHealth = FightSystem.player.entityHealth.currentHealth;

            FightSystem.enemy.animController.PlayDeadAnim();
            yield return new WaitForSeconds(2f);
            FightSystem.ShowVictorySys();
        }

        //Return to main map
        //Play screen animation
        //Teleport player

        
    }

}
