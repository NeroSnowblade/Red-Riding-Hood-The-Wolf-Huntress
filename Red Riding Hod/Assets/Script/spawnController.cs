using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    public GameObject[] spawnpoint;//membuat array spawnpoint
    public GameObject enemyPrivab;//inisiasi enemy
    int jumlahEnemy;// memasukan jumlah enemy
    float couldown = 4; //waktu couldown
    float couldowntime; // variable untuk memuat waktu couldown yang sedang berjalan
    int maxEnemy = 4;//max enemy yang kita spawn
    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectsWithTag("SpawnPoint");// memasukan spawnpoin ke array
        jumlahEnemy = 0; //mengisi jumlah awal agar 0
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
//spauwn enemy dengan couldown
    void SpawnEnemy(){
        if (couldowntime > 0){
            couldowntime -= Time.deltaTime;
        }
        if (couldowntime < 0){
            couldowntime = 0;
        }
        if(couldowntime == 0 && jumlahEnemy < maxEnemy){
            Vector3 randomSpawnPoint = spawnpoint[jumlahEnemy].transform.position;
            GameObject enemy = Instantiate(enemyPrivab,randomSpawnPoint,Quaternion.identity);
            jumlahEnemy++;
            couldowntime = couldown;
        }
        
    }
}
