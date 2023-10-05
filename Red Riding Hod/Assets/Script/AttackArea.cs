using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public enemyMovement enemyMovement;
    private float damage = 10f;
    public bool inAttackRange = false;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<playerAtribut>() != null)
        {
            playerAtribut health = collider.GetComponent<playerAtribut>();
            health.takeDamage(damage);
            inAttackRange = true;
            
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<playerAtribut>() != null)
        {
            inAttackRange = false;   
        }
    }
}
