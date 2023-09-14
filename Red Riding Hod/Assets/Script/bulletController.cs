using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float life=3f;
    // Update is called once per frame
    void Awake()
    {
        Destroy(gameObject,life);
    }
}
