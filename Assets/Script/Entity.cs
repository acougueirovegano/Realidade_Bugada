using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Entity : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected Animator anim;
    protected Collider2D col;

    protected SpriteRenderer sr;


    [Header("Health Detail")]
    [SerializeField] private int maxHealth = 1;
    protected int currentHealth;
    [SerializeField] private Material DamageMaterial;
    [SerializeField] private float damageMaterialDuration = 0.1f;
    private Coroutine damageMaterialCoroutine;
    [Header("Attack Detail")]
    [SerializeField] protected float attackRadius;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask WhatIsTarget;

    [Header("Collision Detail")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatisGround;
    protected bool isGround;
    protected int facingDirection = 1;
    protected bool facingRight = true;

    protected bool canMove = true;
   protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        handleCollision();
        HandleMovement();
        HandleAnimation();
        HandleFlip();
    }

    public void DamageTarget()
    {

        Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, WhatIsTarget);
        foreach (Collider2D enemy in enemyCollider)
        {
            Entity EntityTarget = enemy.GetComponent<Entity>();
            if (EntityTarget != null)
            {
                EntityTarget.TakeDamage();
            }
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        PlayDamageFeedback();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void PlayDamageFeedback()
    {
        if (damageMaterialCoroutine != null)
        {
            StopCoroutine(damageMaterialCoroutine);
        }
        damageMaterialCoroutine = StartCoroutine(DamageFeedbackCo());
    }

    private IEnumerator DamageFeedbackCo()
    {
        Material originalMaterial = sr.material;
        sr.material = DamageMaterial;
        yield return new WaitForSeconds(damageMaterialDuration);
        sr.material = originalMaterial;
    }

    protected virtual void Die()
    {
        this.enabled = false;
        col.enabled = false;
        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);

        Destroy(gameObject, 3);
    }
    public virtual void EnableJumpandMove(bool enable)
    {
        canMove = enable;
    }


   
   
    protected virtual void attemptToAttack()
    {
        if (isGround)
        {
            anim.SetTrigger("attack");

        }
    }

    protected virtual void HandleMovement()
    {
       
    }

    protected virtual void HandleAnimation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetBool("isGround", isGround);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    protected virtual void HandleFlip()
    {
        if (rb.linearVelocity.x > 0 && facingRight == false)
        {
            Flip();
        }
        else if (rb.linearVelocity.x < 0 && facingRight == true)
        {
            Flip();
        }
    }
    protected virtual void handleCollision()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatisGround);

    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDirection *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        if (attackPoint != null)
        {   
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}