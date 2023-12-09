using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject blood;
    public float life;
    public playerAtribut playerAtribut;
    // Update is called once per frame
    void Awake()
    {
        playerAtribut = GameObject.Find("player").GetComponent<playerAtribut>();
        Destroy(gameObject,life);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<enemyAtribut>() !=null)
        {
            col.gameObject.GetComponent<enemyAtribut>().TakeDamage(playerAtribut.damagePlayer);
            // GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
            // newBlood.transform.parent = col.transform;
            Destroy(this.gameObject);
        }
        if(col.GetComponent<BosReg1Atribut>() != null){
            col.gameObject.GetComponent<BosReg1Atribut>().TakeDamage(playerAtribut.damagePlayer);
            Destroy(this.gameObject);
            Debug.Log("ppp");
        }
    }
}
