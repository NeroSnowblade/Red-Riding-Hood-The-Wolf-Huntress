using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pauseUI;
    public string sceneName;
    //public GameObject SetUI;
    //public GameObject finishPanel; //belum dipakai

    void GameStart()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayMusic("Theme");
    }


    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.Instance.PlaySFX("Klik");
    }


    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Klik");
    }

    public void Restart()
    {
        pauseUI.SetActive(false);
        GameStart();
        SceneManager.LoadScene(sceneName);
        //audioManager.PlaySound("Klik");
    }

    public void toMainMenu()
    {
        AudioManager.Instance.PlaySFX("Klik");
        SceneManager.LoadScene("MainMenu");
    }

    public void toShop()
    {
        AudioManager.Instance.PlaySFX("Klik");
        SceneManager.LoadScene("mainShop");
    }

    public void toMapGame()
    {
        SceneManager.LoadScene("mainLv");
        AudioManager.Instance.PlaySFX("Klik");
    }

    public void ButtonMenu()
    {
        AudioManager.Instance.PlaySFX("Klik");
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX("Klik");
        Application.Quit();
        Debug.Log("Quit");
    }

    /*public void CompleteLevel()
      {
         finishPanel.SetActive(true);
         resultUI.SetActive(true);
      }*/
}
