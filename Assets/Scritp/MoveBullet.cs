using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveBullet : MonoBehaviour
{
    public Vector3 hitPoint;

    public GameObject dirt;

    public GameObject blood;

    public int speed;

    //public AudioSource myShot;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Health>().currentHealth -= 20;
            GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
            newBlood.transform.parent = col.transform;
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(dirt, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}