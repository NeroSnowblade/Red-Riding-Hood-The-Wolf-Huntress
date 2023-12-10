using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float moveSpeed = 2.0f;
    public float jumpInterval = 2.0f;
    public float attackRange = 2.0f;
    public float meleeCooldown = 2.0f;
    public float rangedCooldown = 3.0f;
    public float patrolRange = 5.0f;
    public float detectionRadius = 8.0f; 
    public Transform meleeAttackPoint;
    public Transform rangedAttackPoint;
    public LayerMask playerLayer;

    private Rigidbody rb;
    private Animator animator;
    private Transform player;

    private bool canJump = true;
    private bool isFacingRight = true;
    private bool isPatrolling = true;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;

        // Jeda waktu untuk Enemy melompat lagi.
        InvokeRepeating("Jump", 0.0f, jumpInterval);
    }

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            isPatrolling = false; 
        }
        else
        {
            isPatrolling = true; 
        }

        
        if (!isPatrolling)
        {
            if (distanceToPlayer <= attackRange)
            {
                canJump = false;
                animator.SetBool("IsJumping", false);

                if (Time.time >= meleeCooldown)
                {
                    MeleeAttack();
                }
            }
            else
            {
                canJump = true;
            }

            // Membuat Musuh berbalik menghadap Player.
            if (player.position.x < transform.position.x)
            {
                FlipEnemy(false);
            }
            else
            {
                FlipEnemy(true);
            }
        }

       
        if (isPatrolling)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
       
        if (isPatrolling)
        {
            float moveDirection = isFacingRight ? 1.0f : -1.0f;
            rb.velocity = new Vector3(moveDirection * moveSpeed, rb.velocity.y, 0);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    void MeleeAttack()
    {
        animator.SetTrigger("MeleeAttack");
        Collider[] hitPlayers = Physics.OverlapSphere(meleeAttackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayers)
        {
            // memberi damage ke plyer
        }

        meleeCooldown = Time.time + meleeCooldown;
    }

    void FlipEnemy(bool faceRight)
    {
        isFacingRight = faceRight;
        Vector3 scale = transform.localScale;
        scale.x = faceRight ? 1 : -1;
        transform.localScale = scale;
    }

    void Patrol()
    {
        
        if (isFacingRight && transform.position.x >= initialPosition.x + patrolRange)
        {
            FlipEnemy(false);
        }
        else if (!isFacingRight && transform.position.x <= initialPosition.x - patrolRange)
        {
            FlipEnemy(true);
        }
    }
}