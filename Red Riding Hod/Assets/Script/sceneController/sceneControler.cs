using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneControler : MonoBehaviour
{
    public void toMenu(){
        SceneManager.LoadScene("mainMenu");
    }
    public void toMainLv(){
        SceneManager.LoadScene("mainLv");
    }
    public void toShop(){
        SceneManager.LoadScene("mainShop");
    }
}
