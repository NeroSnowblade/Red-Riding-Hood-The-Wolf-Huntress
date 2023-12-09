using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheController : MonoBehaviour
{
    float life = .5f;
    Transform scytheSP;
    playerAtribut scripAtribut;
    void Start(){
        scripAtribut = GameObject.Find("player").GetComponent<playerAtribut>();
        scytheSP = GameObject.Find("scytheSpawnPoint").transform;
    }
    void Update(){
        gameObject.transform.position = scytheSP.position;
    }
    void Awake(){
        Destroy(gameObject,life);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BosReg1Atribut>()!=null){
            other.GetComponent<BosReg1Atribut>().TakeDamage(scripAtribut.damagePlayer*4);
        }
    }
}
