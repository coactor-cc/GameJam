using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, string _animBoolName) : base(_player, _animBoolName){}

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(xInput != 0 )
           player.stateMachine.ChangeState(player.moveState);
    }
}
