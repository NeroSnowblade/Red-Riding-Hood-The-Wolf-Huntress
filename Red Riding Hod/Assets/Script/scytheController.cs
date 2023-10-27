using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheController : MonoBehaviour
{
    float life = .5f;
    Transform scytheSP;
    void Start(){
        scytheSP = GameObject.Find("scytheSpawnPoint").transform;
    }
    void Update(){
        gameObject.transform.position = scytheSP.position;
    }
    void Awake(){
        Destroy(gameObject,life);
    }
}
