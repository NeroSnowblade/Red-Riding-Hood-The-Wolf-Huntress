using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldUiController : MonoBehaviour
{
    public int Gold;

    public TMP_Text goldText;

    public void addGold(int gold)
    {
        Gold += gold;
        goldText.text = Gold.ToString();
    }
    public int getGold()
    {
        return Gold;
    }
}
