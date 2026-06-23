using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Player Movement")]
    [SerializeField] protected float moveSpeed = 5f;
    private float moveInput;
    private bool canJump = true;
    [SerializeField] private float jumpForce = 8;

 protected override void Update()
    {
        base.Update();
        HandleInput();
    }
 void HandleInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
        {
            AttemptToJump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attemptToAttack();
        }
    }
    protected override void HandleMovement()
    {
         if (canMove)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    public override void EnableJumpandMove(bool enable)
    {
        base.EnableJumpandMove(enable);
        canMove = enable;
    }


     void AttemptToJump()
    {
        if (isGround && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.EnableGameOverUi();
    }
}
