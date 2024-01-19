using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerCakaran : MonoBehaviour
{
    public float Damage = 20;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            other.GetComponent<playerAtribut>().takeDamage(Damage);
            Debug.Log("pi");
        }
    }
}
