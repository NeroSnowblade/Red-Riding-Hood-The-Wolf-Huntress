using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMoveController : MonoBehaviour
{
    public float force;
    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<moveBosReg1>() != null){
            Debug.Log("p");
            other.gameObject.GetComponent<moveBosReg1>().jump(force);
        } 
    }
}
