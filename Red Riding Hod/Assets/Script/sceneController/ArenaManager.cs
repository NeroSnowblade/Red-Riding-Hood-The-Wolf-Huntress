using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ArenaManager : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject SetUI;

    public void OpenLevel(int levelId)
    {
        string levelName = "region1Lv " + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void HideMainPanel()
    {
        SetUI.SetActive(false);
        audioManager.PlaySound("Klik");
    }
    // Start is called before the first frame update
    void Start()
    {
        //audio 
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogWarning("Audio Manager dan ditemukan");
        }
        audioManager.PlaySound("BackSound");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
