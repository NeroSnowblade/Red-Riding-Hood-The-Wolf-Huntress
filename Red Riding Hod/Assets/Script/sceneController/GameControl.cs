using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pauseUI;
    public string sceneName;

    // public GameObject finishPanel; //belum dipakai
    //audio
    private AudioManager audioManager;
    public GameObject SetUI;

    public void ShowSettingPanel()
    {
        SetUI.SetActive(true);
        audioManager.PlaySound("Klik");
    }
    public void HideSettingPanel()
    {
        SetUI.SetActive(false);
        audioManager.PlaySound("Klik");
    }

    void GameStart()
    {
        Time.timeScale = 1f;


        //audio
        audioManager.PlaySound("Backsound");


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
        GameStart();
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        audioManager.PlaySound("Klik");
    }


    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlaySound("Klik");
    }

    public void Restart()
    {
        pauseUI.SetActive(false);
        GameStart();
        SceneManager.LoadScene(sceneName);
        audioManager.PlaySound("Klik");
    }
    public void ToMenu()
    {
        GameStart();
        SceneManager.LoadScene("MainMenu");
        audioManager.PlaySound("Klik");
    }
    public void ToShop()
    {
        GameStart();
        SceneManager.LoadScene("mainShop");
        audioManager.PlaySound("Klik");
    }

    public void ToMainLv()
    {
        GameStart();
        SceneManager.LoadScene("mainLv");
        audioManager.PlaySound("Klik");
    }


    public void ToNewLevel(int levelId)
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
        
        string levelName = "region1Lv " + levelId;
        SceneManager.LoadScene(levelName);
    }

    // public void CompleteLevel()
    // {
    //     finishPanel.SetActive(true);

    //     resultUI.SetActive(true);
    // }


    // Update is called once per frame
    void Update()
    {

    }
}
