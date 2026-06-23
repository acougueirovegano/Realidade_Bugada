using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    [Header("Movement Detail")]
    [SerializeField] protected float moveSpeed = 5f;
    private bool playerDetect;
    protected override void Update()
    {
        base.Update();
        attemptToAttack();
    }

    protected override void attemptToAttack()
    {
        if (playerDetect)
        {
            anim.SetTrigger("attack");
        }
    }

    protected override void handleCollision()
    {
        base.handleCollision();
        playerDetect = Physics2D.OverlapCircle(attackPoint.position, attackRadius, WhatIsTarget);
    }
    protected override void HandleMovement()
    {
        if (canMove)
        {
            rb.linearVelocity = new Vector2(moveSpeed * facingDirection, rb.linearVelocity.y);
        }
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.AddKillCount();
    }

    protected override void HandleAnimation()
{
    anim.SetFloat("xVelocity", rb.linearVelocity.x);
}

}
