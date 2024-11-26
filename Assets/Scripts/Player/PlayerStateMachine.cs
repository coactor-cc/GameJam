using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    //value is public if you wanna get but private if you wanna set
    public PlayerState currentState { get; private set; }

    public void Initialize(PlayerState _startstate)
    {
        currentState = _startstate;
        currentState.Enter();
    }
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
