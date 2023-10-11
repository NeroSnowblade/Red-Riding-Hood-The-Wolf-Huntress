using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataWaveLv : MonoBehaviour
{
    public static int WaveLv;
    public static int[] banyakMusuh;
    // Start is called before the first frame update
    void Start()
    {
        WaveLv = 1;
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setup(){
        switch (WaveLv)
        {
            case 1:
                banyakMusuh = new int[waveData.banyakMusuhLv1.Length];
                banyakMusuh = waveData.banyakMusuhLv1;
                break;
            case 2:
                banyakMusuh = new int[waveData.banyakMusuhLv2.Length];
                banyakMusuh = waveData.banyakMusuhLv2;
                break;
            default :
            Debug.Log("Input Wave Lv Salah");
            break;

        }
    }
}
public static class waveData
{
    public static readonly int[] banyakMusuhLv1 = new int[4] {4,5,6,8};
    public static readonly int[] banyakMusuhLv2 = new int[4] {5,5,7,8};
}
