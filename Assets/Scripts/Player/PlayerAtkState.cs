using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkState : PlayerState//
{
    private int comboCounter;
    private int  comboNum= 3;
    private float lastTimeAttacked;
    private float comboWindow = 2f;

    public PlayerAtkState(Player _player, string _animBoolName) : base(_player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (Time.time >= lastTimeAttacked + comboWindow) comboCounter = 0;
        player.anim.SetInteger("ComboCounter", comboCounter);
        AudioManager.instance.PlaySFX(comboCounter);
        //player.anim.speed = 1.2f;                         
        //player.SetVelocity(player.attackMovement[comboCounter].x * player.faceDir, player.attackMovement[comboCounter].y);
        //stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        animTrigger = false;
        comboCounter=(comboCounter+1) %comboNum;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        //if (stateTimer < 0) player.ZeroVelocity();
        if (animTrigger)
            player.stateMachine.ChangeState(player.idleState);
    }
}
