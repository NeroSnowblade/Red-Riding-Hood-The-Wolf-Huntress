using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ArenaManager : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject SetUI;

    public void StartGame()
    {
        SceneManager.LoadScene("region1Lv1");
    }
    public void StartGame2()
    {
        SceneManager.LoadScene("region1Lv2");
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
