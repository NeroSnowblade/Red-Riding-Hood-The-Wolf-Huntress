using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript2 : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody bulletRB;
    public float lifetime = 2.0f; // Lifetime of the bullet in seconds

    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
        {
            Vector3 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z); // Added moveDir.z for 3D movement
        }

        Destroy(this.gameObject, lifetime);
    }

    void Update()
    {
        // You can add any additional update logic here if needed
    }
}
