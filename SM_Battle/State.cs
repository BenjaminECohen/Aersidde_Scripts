using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Concept Referenced from https://www.youtube.com/watch?v=G1bd75R10m4&ab_channel=InfallibleCode

    /// <summary>
    /// Base class for which different states of battle can be inherit from
    /// </summary>

public abstract class State
{
    protected BattleSystem FightSystem;

    public State(BattleSystem fightSystem)
    {
         FightSystem = fightSystem;
    }

    public virtual IEnumerator Start()
    {
        Debug.Log($"<color=cyan>Starting state: {this}</color>");
        yield break;
    }


    public virtual IEnumerator End()
    {
        Debug.Log($"<color=red>Changing state from {this}</color>");
        FightSystem.NextState();
        yield break;
    }


}
