using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtribut : MonoBehaviour
{
    public float hpPlayer;
    public float maxHpPlayer;
    public float damagePlayer;
    public healthPlayerControllerUi healthUi;
    public GameOverUIController GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        maxHpPlayer = 100;
        hpPlayer = maxHpPlayer;
        damagePlayer = 40;
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
