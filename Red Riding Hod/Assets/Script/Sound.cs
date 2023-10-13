using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.7f;
    public bool loop;

    public AudioMixerGroup output;

    [HideInInspector]
    public AudioSource source;

    public void Play()
    {
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
}
