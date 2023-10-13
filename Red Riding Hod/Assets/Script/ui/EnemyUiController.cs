using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUiController : MonoBehaviour
{
    public int MaxEnemy;
    public int enemy;

    public TMP_Text enemyText;

    public void setBanyakEnemy(int bEnemy)
    {
        MaxEnemy = bEnemy;
        enemy = bEnemy;
        enemyText.text = (enemy.ToString() + "/" + MaxEnemy);
    }

    public void enemyMati()
    {
        enemy -= 1;
        Debug.Log(enemy);
        enemyText.text = (enemy.ToString() + "/" + MaxEnemy);
    }
}
