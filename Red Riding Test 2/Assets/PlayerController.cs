using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody rb;
    private Animator animator;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle player input for movement.
        float moveDirection = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveDirection, 0, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // Play animations based on movement.
        if (moveDirection != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Handle jumping.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}