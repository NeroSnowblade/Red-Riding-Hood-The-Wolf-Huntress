using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIController : MonoBehaviour
{
  public GameObject GameOverUI;

  public void setGameOverUI(bool set)
  {
    GameOverUI.SetActive(set);
  }
}
