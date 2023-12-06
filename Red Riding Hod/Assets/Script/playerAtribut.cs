using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtribut : MonoBehaviour
{
    public float hpPlayer;
    public float maxHpPlayer;
    public float damagePlayer;
    public float atkSpeed;
    public healthPlayerControllerUi healthUi;
    public GameOverUIController GameOverUI;
    public DataInGameController data;
    // Start is called before the first frame update
    void Start()
    {
        data.setAtribut();
        Debug.Log(data.maxHp);
        maxHpPlayer = data.maxHp;
        hpPlayer = maxHpPlayer;
        damagePlayer = data.Damage;
        atkSpeed = data.atkSpeed;
        healthUi.setMaxHealth(maxHpPlayer); 
    }

    // Update is called once per frame

    public void takeDamage(float damage){
        if (damage < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negative Damage");
        }

        hpPlayer -= damage;
        Debug.Log("hp player = "+hpPlayer);
        healthUi.setHealth(hpPlayer);
        if(hpPlayer <= 0)
        {
            GameOverUI.setGameOverUI(true);
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
