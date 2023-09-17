using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataWaveLv : MonoBehaviour
{
    public static int WaveLv;
    // Start is called before the first frame update
    void Start()
    {
        WaveLv = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class waveData
{
    public struct dataWaveLv
    {
        public static int[] BanyakEnemy = new int[4];
        public static float[] couldownWave = new float[2];
        public dataWaveLv(int[] BanyakEnemyValue,float[] couldownWaveValue){
            for (int i = 0; i<couldownWaveValue.Length; i++){
            this.couldownWave[i] = couldownWaveValue[i];}
            for (int i = 0; i<BanyakEnemyValue.Length; i++){
            this.BanyakEnemy[i] = BanyakEnemyValue[i];}
        }
    };
    public static readonly dataWaveLv[] leveldata = new dataWaveLv[2]
    {
        new dataWaveLv(new int[4]{3,5,4,8},new float[2]{8f,2f}),
        new dataWaveLv(new int[4]{3,5,4,8},new float[2]{8f,2f})
    };
}
