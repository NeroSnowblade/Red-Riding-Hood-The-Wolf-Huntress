using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatuController : MonoBehaviour
{
    public float life=6;
    public float Damage;
    // Update is called once per frame
    void Awake()
    {
        Damage = GameObject.Find("Bos1").GetComponent<BosReg1Atribut>().DamageAttack;
        Destroy(gameObject,life);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            other.GetComponent<playerAtribut>().takeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
