using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaBat : MonoBehaviour
{

    public float Damage = 10;
    private void Awake()
    {
        Destroy(gameObject,1);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            other.GetComponent<playerAtribut>().takeDamage(Damage);
        }
    }
}
