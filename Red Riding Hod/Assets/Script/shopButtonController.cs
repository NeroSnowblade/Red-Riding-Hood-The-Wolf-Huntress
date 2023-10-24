using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
   public class shopButtonController : MonoBehaviour
   { 
    public shopIUController uiShop;
    public SaveLoadData SaveLoadData;
    public Button UpButShotgun,UpButFlamegun,UpButBazoka,UpButArmor,UpButHp;

    public int totalCoints;
    public int curentLvSg,curentLvFg,curentLvBz,curentLvArmor,curentLvHp;

    void Start()
    {
      totalCoints = 200;
      uiShop.setTotalCointText(totalCoints);

      curentLvSg = uiShop.ShopData.weaponsData[0].unlockLv;
    }

    public void ButtonSgUPMethod(){
         if(uiShop.ShopData.weaponsData[0].isUnlock)
         {
            if(totalCoints >= uiShop.ShopData.weaponsData[0].weaponsLv[curentLvSg+1].costLvUnlock)
            {
            totalCoints -= uiShop.ShopData.weaponsData[0].weaponsLv[curentLvSg+1].costLvUnlock;
            uiShop.ShopData.weaponsData[0].unlockLv += 1;
            curentLvSg = uiShop.ShopData.weaponsData[0].unlockLv;
            }
         }else
         {
            if(totalCoints >= uiShop.ShopData.weaponsData[0].weaponsLv[curentLvSg].costLvUnlock)
            {
            totalCoints -= uiShop.ShopData.weaponsData[0].weaponsLv[curentLvSg].costLvUnlock;
            uiShop.ShopData.weaponsData[0].isUnlock = true;
            }
         }

         uiShop.setTotalCointText(totalCoints);
         uiShop.setSgText(curentLvSg);
#if UNITY_EDITOR
         SaveLoadData.saveData();
#endif
      }

    public void ButtonFgUPMethod(){
      if(uiShop.ShopData.weaponsData[1].isUnlock)
      {
         if(totalCoints >= uiShop.ShopData.weaponsData[1].weaponsLv[curentLvFg+1].costLvUnlock)
         {
            totalCoints -= uiShop.ShopData.weaponsData[1].weaponsLv[curentLvFg+1].costLvUnlock;
            uiShop.ShopData.weaponsData[1].unlockLv += 1;
            curentLvFg = uiShop.ShopData.weaponsData[1].unlockLv;
         }
      }else
      {
         if(totalCoints >= uiShop.ShopData.weaponsData[1].weaponsLv[curentLvFg].costLvUnlock)
         {
            totalCoints -= uiShop.ShopData.weaponsData[1].weaponsLv[curentLvFg].costLvUnlock;
            uiShop.ShopData.weaponsData[1].isUnlock = true;
         }
      }
      uiShop.setTotalCointText(totalCoints);
      uiShop.setFgText(curentLvFg);
#if UNITY_EDITOR
         SaveLoadData.saveData();
#endif
    }

    public void ButtonBzUPMethod(){
      if(uiShop.ShopData.weaponsData[2].isUnlock)
      {
         if(totalCoints >= uiShop.ShopData.weaponsData[2].weaponsLv[curentLvBz+1].costLvUnlock)
         {
            totalCoints -= uiShop.ShopData.weaponsData[2].weaponsLv[curentLvBz+1].costLvUnlock;
            uiShop.ShopData.weaponsData[2].unlockLv += 1;
            curentLvBz = uiShop.ShopData.weaponsData[2].unlockLv;
         }
      }else
      {
         if(totalCoints >= uiShop.ShopData.weaponsData[2].weaponsLv[curentLvBz].costLvUnlock)
         {
            totalCoints -= uiShop.ShopData.weaponsData[2].weaponsLv[curentLvBz].costLvUnlock;
            uiShop.ShopData.weaponsData[2].isUnlock = true;
         }
      }
      uiShop.setTotalCointText(totalCoints);
      uiShop.setBzText(curentLvBz);
#if UNITY_EDITOR
         SaveLoadData.saveData();
#endif
    }

    public void ButtonArmorUPMethod(){
      if(totalCoints >= uiShop.ShopData.playerAttributeData[0].AttributeLv[curentLvArmor+1].costLvUnlock)
      {
         totalCoints -= uiShop.ShopData.playerAttributeData[0].AttributeLv[curentLvArmor+1].costLvUnlock;
         uiShop.ShopData.playerAttributeData[0].unlockLv += 1;
         curentLvArmor = uiShop.ShopData.playerAttributeData[0].unlockLv;
         uiShop.setTotalCointText(totalCoints);
         uiShop.setArmorText(curentLvArmor);
      }
#if UNITY_EDITOR
         SaveLoadData.saveData();
#endif
    }

    public void ButtonHpUPMethod(){
      if(totalCoints >= uiShop.ShopData.playerAttributeData[1].AttributeLv[curentLvHp+1].costLvUnlock)
      {
         totalCoints -= uiShop.ShopData.playerAttributeData[1].AttributeLv[curentLvHp+1].costLvUnlock;
         uiShop.ShopData.playerAttributeData[1].unlockLv += 1;
         curentLvHp = uiShop.ShopData.playerAttributeData[1].unlockLv;
         uiShop.setTotalCointText(totalCoints);
         uiShop.setHpText(curentLvHp);
      }
#if UNITY_EDITOR
      SaveLoadData.saveData();
#endif
    }
   }
} 
