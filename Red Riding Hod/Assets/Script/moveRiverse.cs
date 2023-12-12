using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRiverse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<enemyMovement>()!=null){
            other.GetComponent<enemyMovement>().ReversMove();
            Debug.Log("pp");
        }
        Debug.Log("yy");
    }
}
