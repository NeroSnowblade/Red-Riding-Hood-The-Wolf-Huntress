using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrollingbat : MonoBehaviour
{
    public Transform[] points;
    Vector3 startPos;
    Vector3[] Points = new Vector3[2];
    int current;
    public float speed;

    private void Awake() {
        startPos = gameObject.transform.position;
        Points[0] = new Vector3(startPos.x+2,startPos.y,startPos.z);
        Points[1] = new Vector3(startPos.x-2,startPos.y,startPos.z);
    }

    // Start is called before the first frame update
    void Start()
    {
    current = 0 ;    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Points[current])
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[current], speed * Time.deltaTime);
        }
        else
        {
            current=(current+1)%Points.Length;
        }
    }
}
