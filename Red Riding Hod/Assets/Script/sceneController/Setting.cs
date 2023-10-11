using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider bgSoundSlider;
    [SerializeField] Slider sfxSoundSlider;

    [SerializeField] Toggle muteToggle; // Toggle untuk mute permainan
    private bool isMuted = false; // Status mute saat ini

    void getbgSound()
    {
        float value;
        bool result = masterMixer.GetFloat("BSVolume", out value);
        if (result)
        {
            bgSoundSlider.value = value;
        }
    }

    void getsfxSound()
    {
        float value;
        bool result = masterMixer.GetFloat("SfxVolume", out value);
        if (result)
        {
            sfxSoundSlider.value = value;
        }
    }

    public void setBgSound(float bgSound)
    {
        masterMixer.SetFloat("BSVolume", bgSound);
    }

    public void setSfxSound(float sfxSound)
    {
        masterMixer.SetFloat("SfxVolume", sfxSound);
    }

    public void ToggleMute()
    {
        isMuted = muteToggle.isOn; // Mendapatkan status toggle

        // Mengatur volume suara permainan
        AudioListener.volume = isMuted ? 0f : 1f; // Mengatur volume suara permainan menjadi 0 jika muted, dan 1 jika tidak muted
    }

    // Start is called before the first frame update
    void Start()
    {
        getbgSound();
        getsfxSound();

        // Mengatur status mute sesuai dengan pengaturan awal
        float value;
        bool result = masterMixer.GetFloat("MuteVolume", out value);
        isMuted = (value == -80f); // Menganggap mute jika volume -80dB

        // Mengatur nilai toggle mute sesuai dengan status mute
        muteToggle.isOn = isMuted;

        // Mengatur volume suara permainan saat memulai permainan
        AudioListener.volume = isMuted ? 0f : 1f; // Mengatur volume suara permainan menjadi 0 jika muted, dan 1 jika tidak muted
    }

    // Update is called once per frame
    void Update()
    {

    }
}