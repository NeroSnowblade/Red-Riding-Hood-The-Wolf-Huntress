using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosBatFollow : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    public GameObject bullet;
    public GameObject bulletParent;

    private Transform player;
    private float nexFireTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

       
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {

        transform.position = Vector3. MoveTowards(this.transform.position, player.position, speed * Time. deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nexFireTime < Time.time)
        {
           Instantiate(bullet, bulletParent.transform.position, Quaternion.identity); 
           nexFireTime = Time.time + fireRate;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}

