using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InGameUIController : MonoBehaviour
{
    public GameObject panelComplite;
    public TMP_Text JumlahCoin;
    

    public void PanelCompliteOn(string amount)
    {
        panelComplite.SetActive(true);
        JumlahCoin.text = amount;
    }
    
}

