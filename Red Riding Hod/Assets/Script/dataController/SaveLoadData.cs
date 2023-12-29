using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
public class SaveLoadData : MonoBehaviour
{
    public shopIUController shopUI;

    public void Initialized()
    {
        //clearData();
        if(PlayerPrefs.GetInt("GameStarted") == 1){
            loadData();
        }else{
            saveData();
            PlayerPrefs.SetInt("GameStarted",1);
        }
    }
    public void saveData()
    {
        string ShopDataString = JsonUtility.ToJson(shopUI.ShopData);
        try
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/ShopData.json",ShopDataString);
            Debug.Log("Data Saved");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error Saved Data : " + e);
            throw;
        }

    }
    public void loadData()
    {
        try
        {
            string ShopDataString = System.IO.File.ReadAllText(Application.persistentDataPath + "/ShopData.json");
            shopUI.ShopData = new ShopData();
            shopUI.ShopData = JsonUtility.FromJson<ShopData>(ShopDataString);
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
        PlayerPrefs.SetInt("GameStarted",0);
    }
}
}
