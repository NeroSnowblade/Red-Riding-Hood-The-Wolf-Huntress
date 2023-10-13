using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWaveControler : MonoBehaviour
{
    public enum spawnState {spawning, waiting, counting, ending};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public int BonusGold;
        public float rate;
        public bool isWave;
    }

    public Wave[] waves;
    int nextWave = 0;

    public float timeBetweenWave = 5f;
    public float waveCountdown;

    public float SearchCountdown = 1f;

    public spawnState state = spawnState.counting;
    public GameObject[] spawnPoints;

    public EnemyUiController enemyUI;
    public waveUIController waveUI;
    public stageUIController stageUI;
    public goldUiController goldUI;

    void Start()
    {
        waveCountdown = timeBetweenWave;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        enemyUI = GameObject.Find("ui Enemy remaining").GetComponent<EnemyUiController>();
        waveUI = GameObject.Find("Wave Panel Controller").GetComponent<waveUIController>();
    }

    void Update()
    {
        if (state == spawnState.ending)
        {
            Debug.Log("stage complite");
            string gold = goldUI.getGold().ToString();
            stageUI.PanelCompliteOn(gold);
        }
        if(state == spawnState.waiting) // ketika state menunggu wave
        {
            //mendeteksi enemy yang masih hidup
            if(!EnemyIsAlive())//jika enemy sudah tidak ada
            {
                WaveComplited();//memanggil fungsi waveComplited
            }else{
                return;
            }
        }
        if (waveCountdown<=0) // jika sudah tidak countdown
        {
            if (state != spawnState.spawning && state != spawnState.ending) // jika statenya spawning
            {
                StartCoroutine(SpawnWave( waves[nextWave] ));//memulai wave
            }

        }
        else
        {
            waveCountdown-=Time.deltaTime; // pengurangan countdown
        }
    }
    // memulai wave
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("is wave for "+ _wave.name);
        waveUI.SetPanelWave(_wave.name,false,timeBetweenWave);
        enemyUI.setBanyakEnemy(_wave.count);
        state = spawnState.spawning;
        for (int i = 0; i < _wave.count; i++) // looping spawn enemy
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.rate); // menunggu sesuai wave rate untuk next spawn
        }
        state = spawnState.waiting;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length)].transform; // mengambil spawn point random
        Instantiate(_enemy,_sp.position,_sp.rotation); // spawn enemy
        Debug.Log("spawning enemy : "+_enemy.name);
    }
    // ketika wave sudah selesai
    void WaveComplited()
    {
        Debug.Log("Wave Complited");
        goldUI.addGold(waves[nextWave].BonusGold);
        if(nextWave + 1 > waves.Length - 1)// jika sesi wave lebih besar deri banyak wave - 1
        {
            Debug.Log("you win!"); // game complite
            state = spawnState.ending;
        }else{
            nextWave++; // next sesi
            state = spawnState.counting; // mengembalikan state ke counting
            waveCountdown = timeBetweenWave; // mengembalikan countdown ke waktu tunggu wave
            waveUI.SetPanelWave(waves[nextWave].name,true,timeBetweenWave); // munculin ui wave
        }

    }
    // mendeteksi enemi apakah ada yang masih hidup
    bool EnemyIsAlive()
    {
        SearchCountdown -= Time.deltaTime; // waktu searching
        if(SearchCountdown <= 0)// searching setiap 1 detik
        {
            SearchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // jika enemy tidak ada
            {
                return false;
            }
        }
        return true;
    }

}