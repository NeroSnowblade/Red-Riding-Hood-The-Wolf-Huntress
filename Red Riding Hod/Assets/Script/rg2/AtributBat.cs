using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributBat : MonoBehaviour
{
    public float MaxHp;
    public float Hp;
    public float DamageAttack;
    public int Gold;
    private void Start() {
        Hp = MaxHp;
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
