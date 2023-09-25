using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    int sesi;// sesi digunakan untuk menentukan wave
    int[] banyakMusuh; // digunakan untuk menentukan banyak enemy spawn dalam 1 wave
    public GameObject[] spawnpoint;//membuat array spawnpoint
    public GameObject enemyPrivab;//inisiasi enemy
    int jumlahEnemy;// memasukan jumlah enemy
    float couldowntime; // variable untuk memuat waktu couldown yang sedang berjalan
    bool isRehat = false;
    // Start is called before the first frame update
    void Start()
    {
        sesi = 0;// sesi ke 0 untuk memulai
        banyakMusuh = new int[4]{3,5,4,6}; // membuat length array //memasukan isi array
        spawnpoint = GameObject.FindGameObjectsWithTag("SpawnPoint");// memasukan spawnpoin ke array
        jumlahEnemy = 0; //mengisi jumlah awal agar 0
    }

    // Update is called once per frame
    void Update()
    {
        waveControler();
    }
    //spauwn enemy dengan couldown
    public void couldownSpawnEnemy(float couldownn){
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
    //mengelola wave
    void waveControler(){
        if(sesi < banyakMusuh.Length){
            if (!isRehat){
                if (sesi%2 == 0)
                {
                    couldownSpawnEnemy(4f);
                    //Debug.Log("sesi normal");
                }
                else
                {
                    couldownSpawnEnemy(2f);
                    //Debug.Log("sesi wave");
                }
            }else{
                nextWave(8f);
            }
        }else{//Debug.Log("game over");
        } 
    }
    // membuat couldown untuk menuju sesi selanjutnya
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
            //Debug.Log("jumlah enemy");
            isRehat = false;
            couldowntime = couldownn;
        }
    }
    // spawn enemi di spawn point
    void spawnEnemy(int jumlahEnemy, int MaxEnemy){
        if (jumlahEnemy < MaxEnemy){
                int psPos = jumlahEnemy%spawnpoint.Length;
                Vector3 randomSpawnPoint = spawnpoint[psPos].transform.position;
                GameObject enemy = Instantiate(enemyPrivab,randomSpawnPoint,Quaternion.identity);
        }else
        {
            isRehat = true;
            //Debug.Log("sesi ke" + sesi);
        }
    }
}
