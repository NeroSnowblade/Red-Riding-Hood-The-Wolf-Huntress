using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageUIController1 : MonoBehaviour
{
    public TMP_Text RegionText;

    public void updateTextRegion(int reg){
        RegionText.text = ("Region " + reg); 
    }
}
