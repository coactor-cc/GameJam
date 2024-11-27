using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, string _animBoolName) : base(_player, _animBoolName) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        xInput = 0;
        yInput = 0;
    }

    public override void Update()
    {
        base.Update();

        if (yInput < 0)
        {
            player.rb.velocity = new Vector2(0, player.rb.velocity.y);
        }
        else
        {
            player.rb.velocity = new Vector2(0, player.rb.velocity.y * .2f);
        }

        if (xInput != 0 && player.faceDir != xInput || player.CheckGround() || !player.CheckWall())
        {
            player.stateMachine.ChangeState(player.idleState);
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            player.stateMachine.ChangeState(player.wallJumpState);
        }

    }
}
