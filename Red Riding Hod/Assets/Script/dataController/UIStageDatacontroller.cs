using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStageDatacontroller : MonoBehaviour
{
    public int stageLv;
    public int regionLv;

    public koneksiData koneksiData;
    // Start is called before the first frame update
    void Start()
    {
        getData();
    }

    // Update is called once per frame
    public void getData(){
        stageLv = koneksiData.MainData.MainData.unlockStage;
        regionLv = koneksiData.MainData.MainData.unlockLvRegion;
    }
}
