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
       public TMP_Text LvShotgun,LvFlamegun,LvBazoka,LvArmor,LvHp, txtTotalCoint;
       public TMP_Text SgInfoText,FgInfoText,BzInfoText,ArmorInfoText,HpInfoText;
       public TMP_Text txtUpButShotgun,txtUpButFlamegun,txtUpButBazoka,txtUpButArmor,txtUpButHp;
       public Button UpButShotgun,UpButFlamegun,UpButBazoka,UpButArmor,UpButHp;
    //    public int curentLvSg,curentLvFg,curentLvBz,curentLvArmor,curentLvHp;

       void Start()
       {
            SaveLoadData.Initialized();
            setSgText(ShopData.weaponsData[0].unlockLv);
            setFgText(ShopData.weaponsData[1].unlockLv);
            setBzText(ShopData.weaponsData[2].unlockLv);
            setArmorText(ShopData.playerAttributeData[0].unlockLv);
            setHpText(ShopData.playerAttributeData[1].unlockLv);

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
        if (ShopData.weaponsData[0].isUnlock){
            SgInfoText.text = "Damage : "+ShopData.weaponsData[0].weaponsLv[curentLv].damage+"\nAttack Speed : "+ ShopData.weaponsData[0].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < ShopData.weaponsData[0].weaponsLv.Length - 1)
            {
                txtUpButShotgun.text = "Upgrade Cost "+ShopData.weaponsData[0].weaponsLv[curentLv+1].costLvUnlock;
                LvShotgun.text = "Level " + (curentLv + 1);
            }else if(curentLv >= ShopData.weaponsData[0].weaponsLv.Length - 1)
            {
                UpButShotgun.interactable = false;
                txtUpButShotgun.text = "Max";
                LvShotgun.text = "Level Max";
            }
        }else 
        {
            SgInfoText.text = "(Lock)";
            txtUpButShotgun.text = "Unlock Cost " + ShopData.weaponsData[0].weaponsLv[curentLv].costLvUnlock;
            LvShotgun.text = "Lock";
        }
       }

       public void setFgText(int curentLv)
       {
        if (ShopData.weaponsData[1].isUnlock){
            FgInfoText.text = "Damage : "+ShopData.weaponsData[1].weaponsLv[curentLv].damage+"\nAttack Speed : "+ ShopData.weaponsData[1].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < ShopData.weaponsData[1].weaponsLv.Length - 1)
            {
                txtUpButFlamegun.text = "Upgrade Cost "+ShopData.weaponsData[1].weaponsLv[curentLv+1].costLvUnlock;
                LvFlamegun.text = "Level " + (curentLv + 1);
            }else if(curentLv == ShopData.weaponsData[1].weaponsLv.Length - 1)
            {
                UpButFlamegun.interactable = false;
                txtUpButFlamegun.text = "Max";
                LvFlamegun.text = "Level Max";
            }
        }else 
        {
            FgInfoText.text = "(Lock)";
            txtUpButFlamegun.text = "Unlock Cost " + ShopData.weaponsData[1].weaponsLv[curentLv].costLvUnlock;
            LvFlamegun.text = "Lock";
        }
       }

       public void setBzText(int curentLv)
       {
        if (ShopData.weaponsData[2].isUnlock){
            BzInfoText.text = "Damage : "+ShopData.weaponsData[2].weaponsLv[curentLv].damage+"\nAttack Speed : "+ ShopData.weaponsData[2].weaponsLv[curentLv].atkSpeed;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < ShopData.weaponsData[2].weaponsLv.Length - 1)
            {
                txtUpButBazoka.text = "Upgrade Cost "+ShopData.weaponsData[2].weaponsLv[curentLv+1].costLvUnlock;
                LvBazoka.text = "Level " + (curentLv + 1);
            }else if(curentLv == ShopData.weaponsData[2].weaponsLv.Length - 1)
            {
                UpButBazoka.interactable = false;
                txtUpButBazoka.text = "Max";
                LvBazoka.text = "Level Max";
            }
        }else 
        {
            BzInfoText.text = "(Lock)";
            txtUpButBazoka.text = "Unlock Cost " + ShopData.weaponsData[2].weaponsLv[curentLv].costLvUnlock;
            LvBazoka.text = "Lock";
        }
       }

       public void setArmorText(int curentLv)
       {
            ArmorInfoText.text = "Defence : "+ShopData.playerAttributeData[0].AttributeLv[curentLv].Amount;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < ShopData.playerAttributeData[0].AttributeLv.Length - 1)
            {
                txtUpButArmor.text = "Upgrade Cost "+ShopData.playerAttributeData[0].AttributeLv[curentLv+1].costLvUnlock;
                LvArmor.text = "Level " + (curentLv + 1);
            }else if(curentLv == ShopData.playerAttributeData[0].AttributeLv.Length - 1)
            {
                UpButArmor.interactable = false;
                txtUpButArmor.text = "Max";
                LvArmor.text = "Level Max";
            }
       }

       public void setHpText(int curentLv)
       {
            HpInfoText.text = "Max Hp : "+ShopData.playerAttributeData[1].AttributeLv[curentLv].Amount;
            if(curentLv < 0)
            {
                Debug.Log("curentLv out of range");
            }else if(curentLv < ShopData.playerAttributeData[1].AttributeLv.Length - 1)
            {
                txtUpButHp.text = "Upgrade Cost "+ShopData.playerAttributeData[1].AttributeLv[curentLv+1].costLvUnlock;
                LvHp.text = "Level " + (curentLv + 1);
            }else if(curentLv == ShopData.playerAttributeData[1].AttributeLv.Length - 1)
            {
                UpButHp.interactable = false;
                txtUpButHp.text = "Max";
                LvHp.text = "Level Max";
            }
       }
    }
}