using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class waveUIController : MonoBehaviour
{
    public GameObject panelWave;
    public TMP_Text namaWave;
    public Animator waveAnimator;

    public void SetPanelWave(string nama_Wave, bool set, float timeBetweenWave)
    {
        panelWave.SetActive(set);
        namaWave.text = nama_Wave;
        StartCoroutine(setAnimator(timeBetweenWave));
    }
    IEnumerator setAnimator(float timeBetweenWave)
    {
        waveAnimator.SetBool("isWaveOn",true);
        Debug.Log("true");
        yield return new WaitForSeconds(timeBetweenWave-2);
        waveAnimator.SetBool("isWaveOn",false);
        Debug.Log("false");
    }
}
