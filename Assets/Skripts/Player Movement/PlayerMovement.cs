using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f;
    private float jumpForce = 20f;
    private int scoreCount;

    private float scoreCountTimerTreshold = 1;
    private float scoreCountTimer;

    private Rigidbody2D playerBody;

    private Transform groundCheckPosition;
    [SerializeField]
    private LayerMask groundLayer;

    private bool checkDoubleJump;

    private PlayerAnimationWithTransition playerAnim;

    [SerializeField]
    private float attackWaitTime = 0.5f;
    private float attackTimer;
    private bool attackChecker;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimationWithTransition>();
        groundCheckPosition = transform.GetChild(0).transform;
    }

    private void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttackAction();
    }
    private void FixedUpdate()
    {
        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshold;
            scoreCount++;
            if (scoreCount % 25 == 0)
                moveSpeed++;
        }
        MovePlayer();
    }
    void MovePlayer()
    {
        //if ()
        playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGrounded() && checkDoubleJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    checkDoubleJump = false;
                    playerBody.velocity = Vector2.zero;
                    playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    playerAnim.PlayDoubleJump();
                }

            }
            if (IsGrounded())
            {
                checkDoubleJump = true;
                playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void AnimatePlayer()
    {
        playerAnim.PlayJump(playerBody.velocity.y);
        playerAnim.PlayFromJumpToRunning(IsGrounded());
    }
    void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time > attackTimer)
            {
                attackTimer = Time.time + attackWaitTime;
                attackChecker = true;
                SoundManager.instance.PlayPlayerAttackSound();
            }
        }
    }
    void HandleAttackAction()
    {
        if (attackChecker && IsGrounded())
        {
            attackChecker = false;
            playerAnim.PlayAttack();
        }
        else if (attackChecker && !IsGrounded())
        {
            attackChecker = false;
            playerAnim.PlayJumpAttack();
        }
    }
}
