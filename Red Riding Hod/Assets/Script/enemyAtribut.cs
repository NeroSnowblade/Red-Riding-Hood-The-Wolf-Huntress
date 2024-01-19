using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAtribut : MonoBehaviour
{
    public float maxHpEnemy;
    public float HpEnemy;
    public static float Damage;
    public int Gold;
    private bool isDestroy;

    playerAtribut scripAtribut;
    public Collider scythePrivab; 

    public goldUiController GoldUI;
    public EnemyUiController enemyUI;

    // Start is called before the first frame update
    void Start()
    {
        HpEnemy = maxHpEnemy; 
        Damage = 5f;
        Gold = 5;
        isDestroy = false;

        scripAtribut = FindObjectOfType<playerAtribut>();
        GoldUI = FindObjectOfType<goldUiController>();
        enemyUI = FindObjectOfType<EnemyUiController>();
        
    }    

    public void TakeDamage(float Damage){
        HpEnemy -= Damage;
        Debug.Log(HpEnemy);
        if(HpEnemy <= 0)
            Destroy();
    }

    private void OnTriggerEnter(Collider collider) // cek apakah ada object yang masuk
    {
        // Debug.Log("collision ada"); // muncul di terminal
        if (collider.tag == "Scythe") // cek object yang masuk adalah Scythe (kemungkinan error di sini)
        {
            //Debug.Log("scythe ada"); // tidak muncul di terminal
            TakeDamage(scripAtribut.damagePlayer);
        }
    }

    void Destroy(){
        if(HpEnemy<=0 && !isDestroy){
            GoldUI.addGold(Gold);
            enemyUI?.enemyMati();
            isDestroy = true;
            Destroy(gameObject,.2f);
        }
    }
}
