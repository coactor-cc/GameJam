using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Hardware;
#endif
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    [Header("Features")] 
    //anim bool name is the name of the bool in the animator ”√”⁄set bool
    private string animBoolName;
    protected float xInput,yInput;
    protected bool animTrigger;

    public PlayerState(Player _player, string _animBoolName)
    {
        this.player = _player;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        //reset some values  
        Debug.Log("Enter " + animBoolName);
        player.anim.SetBool(animBoolName, true);
        animTrigger = false;
    }
    public virtual void Update()
    {
        Debug.Log("Update " + animBoolName);
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    public virtual void Exit()
    {
        //reset some values
        Debug.Log("Exit " + animBoolName);
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        animTrigger = true;
    }

}
