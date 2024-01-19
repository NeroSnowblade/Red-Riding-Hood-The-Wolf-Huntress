using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ShopSystem
{
    public class shopIUController : MonoBehaviour
    {
       public ShopData ShopData;
       public SaveLoadData SaveLoadData;
       public SaveLoadDataSlot DataSlot;
       public SaveLoadMainData MainData;
       public SciptableAtribut atributDataLv;
       public TMP_Text LvShotgun,LvFlamegun,LvBazoka,LvArmor,LvHp, txtTotalCoint;
       public TMP_Text SgInfoText,FgInfoText,BzInfoText,ArmorInfoText,HpInfoText;
       public TMP_Text txtUpButShotgun,txtUpButFlamegun,txtUpButBazoka,txtUpButArmor,txtUpButHp;
       public Button UpButShotgun,UpButFlamegun,UpButBazoka,UpButArmor,UpButHp;
    //    public int curentLvSg,curentLvFg,curentLvBz,curentLvArmor,curentLvHp;

       void Start()
       {
            SaveLoadData.Initialized();
            DataSlot.InitializedDataSlot();
            MainData.InitializedMainData();
            setSgText(MainData.MainData.lvAtribut[0].lv);
            setFgText(MainData.MainData.lvAtribut[1].lv);
            setBzText(MainData.MainData.lvAtribut[2].lv);
            setArmorText(MainData.MainData.lvAtribut[3].lv);
            setHpText(MainData.MainData.lvAtribut[4].lv);

            // UpButShotgun.onClick.AddListener(() => ButtonUpgradeMethode(1));
            // UpButFlamegun.onClick.AddListener(() => ButtonUpgradeMethode(2));
            // UpButBazoka.onClick.AddListener(() => ButtonUpgradeMethode(3));
            // UpButArmor.onClick.AddListener(() => ButtonUpgradeMethode(4));
            // UpButHp.onClick.AddListener(() => ButtonUpgradeMethode(5));
       }

       public void setTotalCointText(int totalCoints){
        txtTotalCoint.text = ""+(totalCoints);
       }

       public void setSgText(int curentLv)
       {
        if (MainData.MainData.lvAtribut[0].isUnlock){
            SgInfoText.text = "Damage : "+atributDataLv.WeaponsData[0].weaponsLv[curentLv].damage+"\nAttack Speed : "+ atributDataLv.WeaponsData[0].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < atributDataLv.WeaponsData[0].weaponsLv.Length - 1)
            {
                txtUpButShotgun.text = "Upgrade Cost "+atributDataLv.WeaponsData[0].weaponsLv[curentLv+1].costLvUnlock;
                LvShotgun.text = "Level " + (curentLv + 1);
            }else if(curentLv >= atributDataLv.WeaponsData[0].weaponsLv.Length - 1)
            {
                UpButShotgun.interactable = false;
                txtUpButShotgun.text = "Max";
                LvShotgun.text = "Level Max";
            }
        }else 
        {
            SgInfoText.text = "(Lock)";
            txtUpButShotgun.text = "Unlock Cost " + atributDataLv.WeaponsData[0].weaponsLv[curentLv].costLvUnlock;
            LvShotgun.text = "Lock";
        }
       }

       public void setFgText(int curentLv)
       {
        if (MainData.MainData.lvAtribut[1].isUnlock){
            FgInfoText.text = "Damage : "+atributDataLv.WeaponsData[1].weaponsLv[curentLv].damage+"\nAttack Speed : "+ atributDataLv.WeaponsData[1].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < atributDataLv.WeaponsData[1].weaponsLv.Length - 1)
            {
                txtUpButFlamegun.text = "Upgrade Cost "+atributDataLv.WeaponsData[1].weaponsLv[curentLv+1].costLvUnlock;
                LvFlamegun.text = "Level " + (curentLv + 1);
            }else if(curentLv == atributDataLv.WeaponsData[1].weaponsLv.Length - 1)
            {
                UpButFlamegun.interactable = false;
                txtUpButFlamegun.text = "Max";
                LvFlamegun.text = "Level Max";
            }
        }else 
        {
            FgInfoText.text = "(Lock)";
            txtUpButFlamegun.text = "Unlock Cost " + atributDataLv.WeaponsData[1].weaponsLv[curentLv].costLvUnlock;
            LvFlamegun.text = "Lock";
        }
       }

       public void setBzText(int curentLv)
       {
        if (MainData.MainData.lvAtribut[2].isUnlock){
            BzInfoText.text = "Damage : "+atributDataLv.WeaponsData[2].weaponsLv[curentLv].damage+"\nAttack Speed : "+ atributDataLv.WeaponsData[2].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < atributDataLv.WeaponsData[2].weaponsLv.Length - 1)
            {
                txtUpButBazoka.text = "Upgrade Cost "+atributDataLv.WeaponsData[2].weaponsLv[curentLv+1].costLvUnlock;
                LvBazoka.text = "Level " + (curentLv + 1);
            }else if(curentLv == atributDataLv.WeaponsData[2].weaponsLv.Length - 1)
            {
                UpButBazoka.interactable = false;
                txtUpButBazoka.text = "Max";
                LvBazoka.text = "Level Max";
            }
        }else 
        {
            BzInfoText.text = "(Lock)";
            txtUpButBazoka.text = "Unlock Cost " + atributDataLv.WeaponsData[2].weaponsLv[curentLv].costLvUnlock;
            LvBazoka.text = "Lock";
        }
       }

       public void setArmorText(int curentLv)
       {
            ArmorInfoText.text = "Armor : "+atributDataLv.PlayerAtteributeData[1].AttributeLv[curentLv].Amount;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < atributDataLv.PlayerAtteributeData[1].AttributeLv.Length - 1)
            {
                txtUpButArmor.text = "Upgrade Cost "+atributDataLv.PlayerAtteributeData[1].AttributeLv[curentLv+1].costLvUnlock;
                LvArmor.text = "Level " + (curentLv + 1);
            }else if(curentLv == atributDataLv.PlayerAtteributeData[1].AttributeLv.Length - 1)
            {
                UpButArmor.interactable = false;
                txtUpButArmor.text = "Max";
                LvArmor.text = "Level Max";
            }
       }

       public void setHpText(int curentLv)
       {
            HpInfoText.text = "Max Hp : "+atributDataLv.PlayerAtteributeData[0].AttributeLv[curentLv].Amount;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < atributDataLv.PlayerAtteributeData[0].AttributeLv.Length - 1)
            {
                txtUpButHp.text = "Upgrade Cost "+atributDataLv.PlayerAtteributeData[0].AttributeLv[curentLv+1].costLvUnlock;
                LvHp.text = "Level " + (curentLv + 1);
            }else if(curentLv == atributDataLv.PlayerAtteributeData[0].AttributeLv.Length - 1)
            {
                UpButHp.interactable = false;
                txtUpButHp.text = "Max";
                LvHp.text = "Level Max";
            }
       }
    }
}