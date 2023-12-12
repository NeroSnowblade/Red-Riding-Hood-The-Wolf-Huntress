using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInGameController : MonoBehaviour
{
    public float maxHp;
    public float armor;
    public float Damage;
    public float atkSpeed;

    public int curentLv;
    public int indexWeapon = 0;

    public SaveLoadDataSlot DataSlot;
    public SaveLoadMainData MainData;
    public SciptableAtribut atributDataLv;

    public int index;


    public void saveDataInGame(int gold, int stageLv)
    {
        index = SaveLoadDataSlot.StaticIndexUsed;
        MainData.MainData.totalGold += gold;
        if(stageLv == MainData.MainData.unlockStage){
            if (stageLv == 5){
                DataSlot.DataSlot.DataSlot[index].unlockLvRegion = 2;
                MainData.MainData.unlockLvRegion = 2;
            }else if (stageLv == 10){
                DataSlot.DataSlot.DataSlot[index].unlockLvRegion = 2;
                MainData.MainData.unlockLvRegion = 2;
            }
            DataSlot.DataSlot.DataSlot[index].unlockStage += 1;
            MainData.MainData.unlockStage += 1;  
        }
        DataSlot.saveDataSlot();
        MainData.saveMainData();
    }

    public void setAtribut(){
        curentLv = MainData.MainData.lvAtribut[indexWeapon].lv;

        maxHp = atributDataLv.PlayerAtteributeData[0].AttributeLv[curentLv].Amount;
        Debug.Log("ini: "+maxHp);
        armor = atributDataLv.PlayerAtteributeData[1].AttributeLv[curentLv].Amount;
        Damage = atributDataLv.WeaponsData[indexWeapon].weaponsLv[curentLv].damage;
        atkSpeed = atributDataLv.WeaponsData[indexWeapon].weaponsLv[curentLv].atkSpeed;
    }
}
