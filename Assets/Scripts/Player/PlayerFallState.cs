using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player _player, string _animBoolName) : base(_player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(xInput * .8f * player.speed, player.rb.velocity.y);

        if(player.CheckWall())
            player.stateMachine.ChangeState(player.wallSlideState);
        if (player.CheckGround())
            player.stateMachine.ChangeState(player.moveState);

    }
}
