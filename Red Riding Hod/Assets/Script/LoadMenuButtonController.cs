using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenuButtonController : MonoBehaviour
{
    public SaveLoadDataSlot SaveLoadDataSlot;
    public Button buttonSlot1,buttonSlot2,buttonSlot3,buttonSlot4;
    public sceneControler sceneControler;


    private void Start() {
        buttonSlot1.onClick.AddListener(()=>SlotMethode(0));
        buttonSlot2.onClick.AddListener(()=>SlotMethode(1));
        buttonSlot3.onClick.AddListener(()=>SlotMethode(2));
        buttonSlot4.onClick.AddListener(()=>SlotMethode(3));
    }
    
    public void SlotMethode(int index)
    {
        SaveLoadDataSlot.StaticIndexUsed = index;
        SaveLoadDataSlot.saveDataSlot();
        sceneControler.toMainLv();
    }
}
