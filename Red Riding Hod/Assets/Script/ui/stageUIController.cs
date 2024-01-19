using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InGameUIComplitedController : MonoBehaviour
{
    public GameObject panelComplite;
    public TMP_Text JumlahCoin;
    

    public void PanelCompliteOn(int amount)
    {
        panelComplite.SetActive(true);
        JumlahCoin.text = amount.ToString();
    }
    
}

