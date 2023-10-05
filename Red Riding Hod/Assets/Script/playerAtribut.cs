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
    public void takeDamage(float damage){
        if (damage < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Damage");
        }

        this.hpPlayer -= damage;

        if(hpPlayer <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
