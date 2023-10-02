using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAtribut : MonoBehaviour
{
    public float maxHpEnemy;
    public float HpEnemy;
    public static float Damage;
    playerAtribut scripAtribut;

    // Start is called before the first frame update
    void Start()
    {
        maxHpEnemy = 100f;
        HpEnemy = maxHpEnemy; 
        Damage = 10f;
        isKenaDamage = false;
        scripAtribut = GameObject.Find("player").GetComponent<playerAtribut>();
        
    }    

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float Damage){
        HpEnemy -= Damage;
        Debug.Log(HpEnemy);
    }

    private void OnCollisionEnter(Collision collision) // cek apakah ada object yang masuk
    {
        Debug.Log("collision ada"); // muncul di terminal
        if (collision.collider.tag == "Scythe") // cek object yang masuk adalah Scythe (kemungkinan error di sini)
        {
            Debug.Log("scythe ada"); // tidak muncul di terminal
            TakeDamage(scripAtribut.damagePlayer);
        }
    }
    private void OnCollisionExit(Collision collision) // abaikan dulu
    {
        if (collision.collider.tag == "Scythe"){
        }
    }

}
