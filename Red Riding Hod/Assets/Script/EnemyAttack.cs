using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 2f;
    private float timer = 0f;

    private void Awake()
    {
        attackArea.SetActive(false);
    }
    
    void Update()
    {
        attacking = true;
        attackArea.SetActive(attacking);

        if (attacking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
}
