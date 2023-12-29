using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemDataLoad;

public class SaveLoadMainData : MonoBehaviour
{
    public SaveLoadDataSlot SavedDataSlot;
    public MainDataTemplate MainData;
    public int Index;

    public void InitializedMainData()
    {
        Index = SaveLoadDataSlot.StaticIndexUsed;
        //clearMainData();
        if(!SavedDataSlot.DataSlot.DataSlot[Index].isEmpety){
            loadMainData();
        }else{
            saveMainData();
            SavedDataSlot.DataSlot.DataSlot[Index].isEmpety = false;
            SavedDataSlot.saveDataSlot();
        }
    }
    public void saveMainData()
    {
        string MainDataString = JsonUtility.ToJson(MainData);
        try
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + SavedDataSlot.DataSlot.DataSlot[Index].namaFileJson ,MainDataString);
            Debug.Log("Data Saved");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Saved Data : " + e);
            throw;
        }

    }
    public void loadMainData()
    {
        try
        {
            string MainDataString = System.IO.File.ReadAllText(Application.persistentDataPath + SavedDataSlot.DataSlot.DataSlot[Index].namaFileJson);
            MainData = new MainDataTemplate();
            MainData = JsonUtility.FromJson<MainDataTemplate>(MainDataString);
            Debug.Log("Loaded");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Loaded Data : " + e);
            throw;
        }

    }
    public void clearData()
    {
        SavedDataSlot.DataSlot.DataSlot[Index].isEmpety = true;
        SavedDataSlot.saveDataSlot();
    }
}
