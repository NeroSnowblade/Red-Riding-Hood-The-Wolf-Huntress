using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullettag : MonoBehaviour
{
    public GameObject partikel;
    public float time;
   

    // Update is called once per frame
    void Update()
    {
       time -= Time.deltaTime;
       if(time <= 0)
       if(partikel)
       {
        Instantiate(partikel, transform.position, transform.rotation);
       } 
       Destroy(gameObject);
    }
}
