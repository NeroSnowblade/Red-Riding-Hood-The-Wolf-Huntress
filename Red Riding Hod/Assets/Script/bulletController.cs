using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float life;
    // Update is called once per frame
    void Awake()
    {
        Destroy(gameObject,life);
    }
}
