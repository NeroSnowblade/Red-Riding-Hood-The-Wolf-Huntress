using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float gayadorong;
    public Transform player;
    public Rigidbody rb;
    float arahloncatan;
    float couldown = 3;
    float couldowntime;
    // Start is called before the first frame update
    void Start()
    {
        gayadorong = 2f;
        player = GameObject.Find("player").transform;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        loncat();
    }

    void loncat(){
        if (couldowntime > 0){
            couldowntime -= Time.deltaTime;
        }
        if (couldowntime < 0){
            couldowntime = 0;
        }
        if(couldowntime == 0){
            arahloncatan = player.position.x - transform.position.x; // menentukan arah arahloncatan
            if(arahloncatan < 0){
                arahloncatan = -1f;
            }
            else if(arahloncatan > 0){
                arahloncatan = 1f;
            }
            rb.AddForce(new Vector3(arahloncatan,1f,0)*gayadorong,ForceMode.VelocityChange); // memberi gaya arahloncatan pada object
            couldowntime = couldown;
        }
    }
}

