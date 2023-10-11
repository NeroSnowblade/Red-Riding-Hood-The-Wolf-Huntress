using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWaveControler : MonoBehaviour
{
    int sesi;
    int[] banyakMusuh;
    public GameObject[] spawnpoint;//membuat array spawnpoint
    public GameObject enemyPrivab;//inisiasi enemy
    int jumlahEnemy;// memasukan jumlah enemy
    float couldown; //waktu couldown
    float couldowntime; // variable untuk memuat waktu couldown yang sedang berjalan
    bool isRehat = false;
    // Start is called before the first frame update
    void Start()
    {
        sesi = 0;
        banyakMusuh = new int[dataWaveLv.banyakMusuh.Length];
        banyakMusuh = dataWaveLv.banyakMusuh;
        spawnpoint = GameObject.FindGameObjectsWithTag("SpawnPoint");// memasukan spawnpoin ke array
        jumlahEnemy = 0; //mengisi jumlah awal agar 0
    }

    // Update is called once per frame
    void Update()
    {
        waveControler();
    }
//spauwn enemy dengan couldown
    public void SpawnEnemy(float couldownn){
        if (couldowntime > 0){
            couldowntime -= Time.deltaTime;
        }
        else if (couldowntime < 0){
            couldowntime = 0;
        }
        else if (couldowntime == 0){
            spawnEnemy(jumlahEnemy,banyakMusuh[sesi]);
            jumlahEnemy++;
            couldowntime = couldownn;
        }
    }
    void waveControler(){
        if(sesi < banyakMusuh.Length){
            if (!isRehat){
                if (sesi%2 == 0)
                {
                    SpawnEnemy(4f);
                    Debug.Log("sesi normal");
                }
                else
                {
                    SpawnEnemy(2f);
                    Debug.Log("sesi wave");
                }
            }else{
                nextWave(8f);
            }
        }else{Debug.Log("game over");} 
    }
    void nextWave(float couldownn){
        if (couldowntime > 0){
            couldowntime -= Time.deltaTime;
        }
        if (couldowntime < 0){
            couldowntime = 0;
        }
        if(couldowntime == 0){
            sesi++;
            jumlahEnemy=0;
            Debug.Log("jumlah enemy");
            isRehat = false;
            couldowntime = couldownn;
        }
    }
    void spawnEnemy(int jumlahEnemy, int MaxEnemy){
        if (jumlahEnemy < MaxEnemy){
                int psPos = jumlahEnemy%spawnpoint.Length;
                Vector3 randomSpawnPoint = spawnpoint[psPos].transform.position;
                GameObject enemy = Instantiate(enemyPrivab,randomSpawnPoint,Quaternion.identity);
        }else
        {
            isRehat = true;
            Debug.Log("sesi ke" + sesi);
        }
    }

}