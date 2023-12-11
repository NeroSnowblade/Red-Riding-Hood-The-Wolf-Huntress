using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBatKecil : MonoBehaviour
{
    public bool inRange = false;
    float atkSpeed = 2f;
    float timeAtk = 0;
    public GameObject AttackBat;
    public Transform playerPos;

    private void Start() {
        playerPos = GameObject.Find("player").transform;
    }
    private void Update() {
        attack();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            inRange=true;
        }
        Debug.Log("p");
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<playerAtribut>() != null){
            inRange=false;
        }
    }

    private void attack(){
        if (inRange){
            if(timeAtk <= 0){
                var attack = Instantiate(AttackBat,playerPos.position,playerPos.rotation);
                timeAtk = atkSpeed;
            }else{
                timeAtk -= Time.deltaTime;
            }
        }
    }
}
