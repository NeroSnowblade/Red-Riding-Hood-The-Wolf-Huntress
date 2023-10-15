using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float jumpInterval;
    public float attackRange;

    private Rigidbody rb;
    private Transform player;

    private bool canJump;
    private bool isFacingRight; // Untuk mengontrol arah yang enemy hadapi or hadapin? entahlah.

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 5.0f;
        moveSpeed = 2.0f;
        jumpInterval = 3.0f;
        attackRange = 1.5f;

        canJump = true;
        isFacingRight = true;

        player = GameObject.Find("player").transform;
        rb = this.GetComponent<Rigidbody>();

         // Jeda waktu untuk Enemy melompat lagi.
        InvokeRepeating("Jump",0.0f,jumpInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Menentukan apakah Player sudah masuk jarak serang Enemy.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            // Berhenti melompat ketika Player masuk ke jarang serang Enemy.
            canJump = false;
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

    void Jump()
    {
        if (canJump)
        {
            // Penerapan Jump Force untuk lompatan Enemy.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             // Movement Musuh berjalan secara Horizontal.
            float moveDirection = isFacingRight ? 1.0f : -1.0f;
            rb.velocity = new Vector3(moveDirection * moveSpeed, rb.velocity.y, 0);
        }
    }

    void FlipEnemy(bool faceRight)
    {
        // Membalikkan Sprite musuh ke arah yang ditentukan.
        isFacingRight = faceRight; 
        transform.rotation = faceRight ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,180,0);
    }
}

