using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemDataLoad;


public class SaveLoadDataSlot : MonoBehaviour
{
    public DataSlotTemplate DataSlot;
    public static int StaticIndexUsed;

    public void InitializedDataSlot()
    {
        //clearDataSlot();
        if(PlayerPrefs.GetInt("GameStarted") == 1){
            loadDataSlot();
        }else{
            saveDataSlot();
            PlayerPrefs.SetInt("GameStarted",1);
        }
    }
    public void saveDataSlot()
    {
        string DataSlotString = JsonUtility.ToJson(DataSlot);
        try
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/DataSlot.json",DataSlotString);
            Debug.Log("Data Saved");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Saved Data : " + e);
            throw;
        }

    }
    public void loadDataSlot()
    {
        try
        {
            string DataSlotString = System.IO.File.ReadAllText(Application.persistentDataPath + "/DataSlot.json");
            DataSlot = new DataSlotTemplate();
            DataSlot = JsonUtility.FromJson<DataSlotTemplate>(DataSlotString);
            Debug.Log("Loaded");
        }
        catch (System.Exception e)
        {
            saveDataSlot();
            Invoke("loadDataSlot", 0.1f);
            Debug.Log("Error Loaded Data : " + e);
            throw;
        }

    }
    public void clearDataSlot()
    {
        PlayerPrefs.SetInt("GameStarted",0);
    }
}
