using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosReg1Atribut : MonoBehaviour
{
    public float MaxHp;
    public float Hp;
    public float DamageAttack;
    public int Gold;
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 1000f;
        Hp = MaxHp;
        DamageAttack = 20;
        Gold = 200;
    }

    public void TakeDamage(float Damage){
        Hp -= Damage;
        Debug.Log("hp enemy = "+Hp);
        if(Hp<=0){
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    
}
