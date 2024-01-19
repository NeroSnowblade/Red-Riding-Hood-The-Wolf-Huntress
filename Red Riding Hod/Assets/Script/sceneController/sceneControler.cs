using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneControler : MonoBehaviour
{
    public void toMenu(){
        SceneManager.LoadScene("mainMenu");
    }
    public void toMainLv(){
        SceneManager.LoadScene("mainLv");
    }
    public void toShop(){
        SceneManager.LoadScene("mainShop");
    }
    public void toLoadMenu()
    {
        SceneManager.LoadScene("LoadMenu");
    }
    public void toGame(int region,int lv)
    {
        if(region==1){
            if(lv==1)SceneManager.LoadScene("region1Lv 1");
            if(lv==2)SceneManager.LoadScene("region1Lv 2");
            if(lv==3)SceneManager.LoadScene("region1Lv 3");
            if(lv==4)SceneManager.LoadScene("region1Lv 4");
            if(lv==5)SceneManager.LoadScene("region1Lv 5");
        }
        if(region==2){
            if(lv==1)SceneManager.LoadScene("region2Lv 1");
            if(lv==2)SceneManager.LoadScene("region2Lv 2");
            if(lv==3)SceneManager.LoadScene("region2Lv 3");
            if(lv==4)SceneManager.LoadScene("region2Lv 4");
            if(lv==5)SceneManager.LoadScene("region2Lv 5");
        }
        if(region==3){
            if(lv==1)SceneManager.LoadScene("region3Lv 1");
            if(lv==2)SceneManager.LoadScene("region3Lv 2");
            if(lv==3)SceneManager.LoadScene("region3Lv 3");
            if(lv==4)SceneManager.LoadScene("region3Lv 4");
            if(lv==5)SceneManager.LoadScene("region3Lv 5");
        }
    }
    public void OpenLevelReg1(int levelId)
    {
        string levelName = "region1Lv " + levelId;
        SceneManager.LoadScene(levelName);
    }
    public void OpenLevelReg2(int levelId)
    {
        string levelName = "region2Lv " + levelId;
        SceneManager.LoadScene(levelName);
    }
    public void OpenLevelReg3(int levelId)
    {
        string levelName = "region3Lv " + levelId;
        SceneManager.LoadScene(levelName);
    }
    
}
