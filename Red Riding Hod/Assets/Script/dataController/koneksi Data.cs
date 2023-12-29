using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koneksiData : MonoBehaviour
{
    public SaveLoadDataSlot DataSlot;
    public SaveLoadMainData MainData;

    // Start is called before the first frame update
    void Awake()
    {
        DataSlot.loadDataSlot();
        MainData.InitializedMainData();
    }

    // Update is called once per frame
    
}
