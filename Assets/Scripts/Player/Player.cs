using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Tilemaps;
#endif
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 12f;
    public float jumpForce = 10f;
    [Header("Ground Check")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected LayerMask Ground;
    [SerializeField] protected float groundCheckDistance;
    [Header("Wall Check")]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; } = null;
    #endregion
    [SerializeField] public int faceDir { get; private set; } = 1;// 1 right -1 left
    //add system event
    public System.Action onFlip;
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerAtkState atkState { get; private set; }
    #endregion
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, "Idle");
        moveState = new PlayerMoveState(this, "Move");
        jumpState = new PlayerJumpState(this, "Jump");
        fallState = new PlayerFallState(this, "Jump");
        wallSlideState = new PlayerWallSlideState(this, "WallSlide");
        atkState = new PlayerAtkState(this, "Atk");

    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        stateMachine.Initialize(idleState);
    }
    private void Update()
    {
        stateMachine.currentState.Update();
    }
    public void AnimTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    #region Velocity
    public void ZeroVelocity() => rb.velocity = Vector2.zero;
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipCtrl(_xVelocity);
    }
    #endregion
    #region Collison
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + faceDir * wallCheckDistance, wallCheck.position.y));
    }

    public bool CheckGround() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, Ground);
    public bool CheckWall() => Physics2D.Raycast(wallCheck.position, Vector2.right * faceDir, wallCheckDistance, Ground);
    #endregion
    #region Flip
    private void FlipCtrl(float x)
    {
        if (x > 0 && faceDir == -1) Flip();
        else if (x < 0 && faceDir == 1) Flip();
    }
    private void Flip()
    {
        if (spriteRenderer != null)
        {
            faceDir = -faceDir;
            //spriteRenderer.flipX = !spriteRenderer.flipX;
            transform.Rotate(0, 180, 0);
            onFlip?.Invoke();
        }
    }
    #endregion
}
