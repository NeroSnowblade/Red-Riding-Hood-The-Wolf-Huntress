using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
   public class shopButtonController : MonoBehaviour
   { 
    public shopIUController uiShop;
    public SaveLoadMainData MainData;
    public SciptableAtribut AtributData;

    public sceneControler sceneControler;

    public Button UpButShotgun,UpButFlamegun,UpButBazoka,UpButArmor,UpButHp;
    public Button BtStart,BtStageMenu;

    public int totalCoints;
    public int curentLvSg,curentLvFg,curentLvBz,curentLvArmor,curentLvHp;

    void Start()
    {
      totalCoints = MainData.MainData.totalGold;
      uiShop.setTotalCointText(totalCoints);

      curentLvSg = MainData.MainData.lvAtribut[0].lv;
      curentLvFg = MainData.MainData.lvAtribut[1].lv;
      curentLvBz = MainData.MainData.lvAtribut[2].lv;
      curentLvHp = MainData.MainData.lvAtribut[3].lv;
      curentLvArmor = MainData.MainData.lvAtribut[4].lv;

      BtStart.onClick.AddListener(() => sceneControler.toGame(MainData.MainData.unlockLvRegion,MainData.MainData.unlockStage));
    }

    public void ButtonSgUPMethod(){
         if(MainData.MainData.lvAtribut[0].isUnlock)
         {
            if(totalCoints >= AtributData.WeaponsData[0].weaponsLv[curentLvSg+1].costLvUnlock)
            {
            totalCoints -= AtributData.WeaponsData[0].weaponsLv[curentLvSg+1].costLvUnlock;
            MainData.MainData.lvAtribut[0].lv += 1;
            curentLvSg = MainData.MainData.lvAtribut[0].lv;
            }
         }else
         {
            if(totalCoints >= AtributData.WeaponsData[0].weaponsLv[curentLvSg].costLvUnlock)
            {
            totalCoints -= AtributData.WeaponsData[0].weaponsLv[curentLvSg+1].costLvUnlock;
            MainData.MainData.lvAtribut[0].isUnlock = true;
            }
         }

         MainData.MainData.totalGold = totalCoints;
         uiShop.setTotalCointText(totalCoints);
         uiShop.setSgText(curentLvSg);
#if UNITY_EDITOR
         MainData.saveMainData();
#endif
      }

    public void ButtonFgUPMethod(){
      if(MainData.MainData.lvAtribut[1].isUnlock)
      {
         if(totalCoints >= AtributData.WeaponsData[1].weaponsLv[curentLvFg+1].costLvUnlock)
         {
            totalCoints -= AtributData.WeaponsData[1].weaponsLv[curentLvFg+1].costLvUnlock;
            MainData.MainData.lvAtribut[1].lv += 1;
            curentLvFg = MainData.MainData.lvAtribut[1].lv;
         }
      }else
      {
         if(totalCoints >= AtributData.WeaponsData[1].weaponsLv[curentLvFg].costLvUnlock)
         {
            totalCoints -= AtributData.WeaponsData[1].weaponsLv[curentLvFg].costLvUnlock;
            MainData.MainData.lvAtribut[1].isUnlock = true;
         }
      }

      MainData.MainData.totalGold = totalCoints;
      uiShop.setTotalCointText(totalCoints);
      uiShop.setFgText(curentLvFg);
#if UNITY_EDITOR
         MainData.saveMainData();
#endif
    }

    public void ButtonBzUPMethod(){
      if(MainData.MainData.lvAtribut[2].isUnlock)
      {
         if(totalCoints >= AtributData.WeaponsData[2].weaponsLv[curentLvBz+1].costLvUnlock)
         {
            totalCoints -= AtributData.WeaponsData[2].weaponsLv[curentLvBz+1].costLvUnlock;
            MainData.MainData.lvAtribut[2].lv += 1;
            curentLvBz = MainData.MainData.lvAtribut[2].lv;
         }
      }else
      {
         if(totalCoints >= AtributData.WeaponsData[2].weaponsLv[curentLvBz].costLvUnlock)
         {
            totalCoints -= AtributData.WeaponsData[2].weaponsLv[curentLvBz].costLvUnlock;
            MainData.MainData.lvAtribut[2].isUnlock = true;
         }
      }

      MainData.MainData.totalGold = totalCoints;
      uiShop.setTotalCointText(totalCoints);
      uiShop.setBzText(curentLvBz);
#if UNITY_EDITOR
         MainData.saveMainData();
#endif
    }

    public void ButtonArmorUPMethod(){
      if(totalCoints >= AtributData.PlayerAtteributeData[0].AttributeLv[curentLvArmor+1].costLvUnlock)
      {
         totalCoints -= AtributData.PlayerAtteributeData[0].AttributeLv[curentLvArmor+1].costLvUnlock;
         MainData.MainData.lvAtribut[3].lv += 1;
         curentLvArmor = MainData.MainData.lvAtribut[0].lv;
         MainData.MainData.totalGold = totalCoints;
         uiShop.setTotalCointText(totalCoints);
         uiShop.setArmorText(curentLvArmor);
      }
#if UNITY_EDITOR
         MainData.saveMainData();
#endif
    }

    public void ButtonHpUPMethod(){
      if(totalCoints >= AtributData.PlayerAtteributeData[1].AttributeLv[curentLvHp+1].costLvUnlock)
      {
         totalCoints -= AtributData.PlayerAtteributeData[1].AttributeLv[curentLvHp+1].costLvUnlock;
         MainData.MainData.lvAtribut[4].lv += 1;
         curentLvHp = MainData.MainData.lvAtribut[4].lv;
         MainData.MainData.totalGold = totalCoints;
         uiShop.setTotalCointText(totalCoints);
         uiShop.setHpText(curentLvHp);
      }
#if UNITY_EDITOR
      MainData.saveMainData();
#endif
    }
   }
} 
