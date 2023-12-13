using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeScriptButton : MonoBehaviour
{
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image targetButton;

    public void ChangeSprite()
    {
        if(targetButton.sprite == buttonSprites[0])
        {
            AudioManager.Instance.PlaySFX("Klik");
            targetButton.sprite = buttonSprites[1];
            return;
        }

        targetButton.sprite = buttonSprites[0];
    }
}
