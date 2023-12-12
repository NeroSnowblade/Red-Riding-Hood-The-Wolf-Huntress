using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBatController : MonoBehaviour
{
    public float live;
    public float Damage;

    private void Awake() {
        Destroy(gameObject,live);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            other.GetComponent<playerAtribut>().takeDamage(Damage);
            Destroy(gameObject);
        }
        Debug.Log("yyyy");
    }
}
