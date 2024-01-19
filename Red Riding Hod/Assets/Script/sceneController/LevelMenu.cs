using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public int regionKe;
    public int unlockedLevel;
    public Button[] buttons;
    public GameObject levelButtons;
    public UIStageDatacontroller uiData;

    private void Awake()
    {
        uiData.getData();
        Debug.Log(regionKe);
        Debug.Log("ini :"+ uiData.regionLv);
        ButtonsToArray();
        unlockButton();
        for (int i = 0; i<buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i<unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for(int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    void unlockButton(){
        if (regionKe <= uiData.regionLv){
            unlockedLevel = uiData.stageLv -(5*(regionKe-1));
        }
        else{
            unlockedLevel = 0;
        }
    }
}
