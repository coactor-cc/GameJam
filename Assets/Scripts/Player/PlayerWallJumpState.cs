using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, string _animBoolName) : base(_player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(-player.faceDir * 3, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.rb.velocity.y < 0)
        {
            player.stateMachine.ChangeState(player.fallState);
        }
        else if (player.CheckWall())
        {
            player.stateMachine.ChangeState(player.wallSlideState);
        }
        else if (xInput != 0)
        {
            player.SetVelocity(xInput * .8f * player.speed, player.rb.velocity.y);
        }
    }
}
