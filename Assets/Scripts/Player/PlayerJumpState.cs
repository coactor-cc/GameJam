using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player,  string animBoolName) : base(player, animBoolName) { }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.rb.velocity.x, player.jumpForce);
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
        else if (xInput != 0)
        {
            player.SetVelocity(xInput * .8f * player.speed, player.rb.velocity.y);
        }
    }
}
