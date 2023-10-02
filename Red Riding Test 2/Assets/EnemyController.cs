using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float moveSpeed = 2.0f;
    public float jumpInterval = 2.0f;
    public float attackRange = 2.0f;

    private Rigidbody rb;
    private Animator animator;
    private Transform player;

    private bool canJump = true;
    private bool isFacingRight = true; // Untuk mengontrol arah yang enemy hadapi or hadapin? entahlah.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Jeda waktu untuk Enemy melompat lagi.
        InvokeRepeating("Jump", 0.0f, jumpInterval);
    }

    void Update()
    {
        // Menentukan apakah Player sudah masuk jarak serang Enemy.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            // Berhenti melompat ketika Player masuk ke jarang serang Enemy.
            canJump = false;
            animator.SetBool("IsJumping", false);
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

    void FixedUpdate()
    {
        // Movement Musuh berjalan secara Horizontal.
        float moveDirection = isFacingRight ? 1.0f : -1.0f;
        rb.velocity = new Vector3(moveDirection * moveSpeed, rb.velocity.y, 0);
    }

    void Jump()
    {
        if (canJump)
        {
            // Penerapan Jump Force untuk lompatan Enemy.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    void FlipEnemy(bool faceRight)
    {
        // Membalikkan Sprite musuh ke arah yang ditentukan.
        isFacingRight = faceRight;
        Vector3 scale = transform.localScale;
        scale.x = faceRight ? 1 : -1;
        transform.localScale = scale;
    }
}