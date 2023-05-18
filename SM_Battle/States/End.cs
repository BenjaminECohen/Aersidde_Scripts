using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// End of Combat State specific Start and End functionalities
/// </summary>

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
        }
        else
        {
            Debug.Log("Player Wins");

            FightSystem.player.stats.currentHealth = FightSystem.player.entityHealth.currentHealth; //Assign player stats from the battle to the player scriptable object stats to save between scenes

            FightSystem.enemy.animController.PlayDeadAnim();
            yield return new WaitForSeconds(2f);
            FightSystem.ShowVictorySys(); //Open Victory screen UI to handle stat increases and button to return to map/node scene
        }

        
    }

}
