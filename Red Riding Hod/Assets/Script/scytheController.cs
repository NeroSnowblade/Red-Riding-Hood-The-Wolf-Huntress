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
    private void OnTriggerEnter(Collider col) {
        if (col.GetComponent<enemyAtribut>() !=null)
        {
            col.gameObject.GetComponent<enemyAtribut>().TakeDamage(scripAtribut.damagePlayer);
            // GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
            // newBlood.transform.parent = col.transform;
            Destroy(this.gameObject);
        }
        if(col.GetComponent<BosReg1Atribut>() != null){
            col.gameObject.GetComponent<BosReg1Atribut>().TakeDamage(scripAtribut.damagePlayer);
            Destroy(this.gameObject);
            Debug.Log("ppp");
        }
        if(col.GetComponent<AtributBat>() != null){
            col.gameObject.GetComponent<AtributBat>().TakeDamage(scripAtribut.damagePlayer);
            Destroy(this.gameObject);
            Debug.Log("ppp");
        }
    }
}
