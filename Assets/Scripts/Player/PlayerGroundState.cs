using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, string _animBoolName) : base(_player, _animBoolName)
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
        if(Input.GetKeyDown(KeyCode.Mouse0))//攻击
            player.stateMachine.ChangeState(player.atkState);

        if (Input.GetKeyDown(KeyCode.Space) && player.CheckGround())// 避免从物品起跳
            player.stateMachine.ChangeState(player.jumpState);

        if (!player.CheckGround())//掉落
            player.stateMachine.ChangeState(player.fallState);

    }
}
