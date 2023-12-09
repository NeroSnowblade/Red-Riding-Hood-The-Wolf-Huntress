using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
     public GameObject player;
    private Transform playerPos;
    private Vector3 startingPos;
    public float distance;
    public float speedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);

        if (distanceToPlayer < distance)
        {
            // Move towards the player if within the specified distance
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
        }
        else
        {
            // Move back to the starting position if the player is too far away
            transform.position = Vector3.MoveTowards(transform.position, startingPos, speedEnemy * Time.deltaTime);
        }
    }
}
