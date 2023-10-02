using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAtribut : MonoBehaviour
{
    public float maxHpEnemy;
    public float HpEnemy;
    public static float Damage;
    playerAtribut scripAtribut;
    public Collider scythePrivab; 

    // Start is called before the first frame update
    void Start()
    {
        maxHpEnemy = 100f;
        HpEnemy = maxHpEnemy; 
        Damage = 10f;
        scripAtribut = GameObject.Find("player").GetComponent<playerAtribut>();
        
    }    

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

    public void TakeDamage(float Damage){
        HpEnemy -= Damage;
        Debug.Log(HpEnemy);
    }

    private void OnTriggerEnter(Collider collider) // cek apakah ada object yang masuk
    {
        // Debug.Log("collision ada"); // muncul di terminal
        if (collider.tag == "Scythe") // cek object yang masuk adalah Scythe (kemungkinan error di sini)
        {
            Debug.Log("scythe ada"); // tidak muncul di terminal
            TakeDamage(scripAtribut.damagePlayer);
        }
    }

    void Destroy(){
        if(HpEnemy<=0){
            Destroy(gameObject);
        }
    }

}
