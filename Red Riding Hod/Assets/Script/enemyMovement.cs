using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float jumpInterval;
    public float attackRange;
    public bool keKanan = true;

    private Rigidbody rb;
    private Transform player;
    private Vector3 initialPosition;

    private bool canJump;
    private bool canMove;
    private bool isFacingRight; // Untuk mengontrol arah yang enemy hadapi or hadapin? entahlah.

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 5.0f;
        moveSpeed = 1.8f;
        jumpInterval = 3.0f;
        attackRange = 1f;

        canJump = true;
        canMove = true;
        isFacingRight = true;

        player = GameObject.Find("player").transform;
        rb = this.GetComponent<Rigidbody>();

        initialPosition = transform.position;

         // Jeda waktu untuk Enemy melompat lagi.
        // InvokeRepeating("Jump",0.0f,jumpInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Menentukan apakah Player sudah masuk jarak serang Enemy.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            // Berhenti melompat ketika Player masuk ke jarang serang Enemy.
            canMove = false;
            if (player.position.x < transform.position.x)
            {
                FlipEnemy(false);
            }
            else
            {
                FlipEnemy(true);
            }
        }
        else
        {
            canMove = true;
            FlipEnemy(keKanan);
        }

        // Membuat Musuh berbalik menghadap Player.
        move();
    }

    void move()
    {
        if (canMove)
        {
            // Penerapan Jump Force untuk lompatan Enemy.
             // Movement Musuh berjalan secara Horizontal.
            float moveDirection = keKanan ? 1.0f : -1.0f;
            rb.velocity = new Vector3(moveDirection * moveSpeed, 0, 0);
        }
    }

    void FlipEnemy(bool faceRight)
    {
        // Membalikkan Sprite musuh ke arah yang ditentukan.
        isFacingRight = faceRight; 
        transform.rotation = faceRight ? Quaternion.Euler(0,90,0) : Quaternion.Euler(0,270,0);
    }

    public void ReversMove(){
        keKanan = !keKanan;
    }
    
}

