using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Concept Referenced from https://www.youtube.com/watch?v=G1bd75R10m4&ab_channel=InfallibleCode

/// <summary>
///  Statemachine to run the battle system
/// </summary>

public abstract class StateMachine : MonoBehaviour
{
    protected State State;

    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }
}
