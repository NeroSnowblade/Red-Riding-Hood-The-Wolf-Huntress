using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

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

    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
