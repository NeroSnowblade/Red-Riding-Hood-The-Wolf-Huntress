using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtribut : MonoBehaviour
{
    public float hpPlayer;
    public float maxHpPlayer;
    public float damagePlayer;
    // Start is called before the first frame update
    void Start()
    {
        maxHpPlayer = 100;
        hpPlayer = maxHpPlayer;
        damagePlayer = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
