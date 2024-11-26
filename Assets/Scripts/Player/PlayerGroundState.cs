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
        if(Input.GetKeyDown(KeyCode.Mouse0))//����
            player.stateMachine.ChangeState(player.atkState);

        if (Input.GetKeyDown(KeyCode.Space) && player.CheckGround())// �������Ʒ����
            player.stateMachine.ChangeState(player.jumpState);

        if (!player.CheckGround())//����
            player.stateMachine.ChangeState(player.fallState);

    }
}
