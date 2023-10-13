using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


/// <summary>
/// SttingsMenuControl is class for control settings menu
/// </summary>
public class SettingsMenuControl : MonoBehaviour
{
    public AudioMixerGroup mixer;

    public Vector2 masterVolBounds = new Vector2(-80, 0);                                    // min/max value master volume in mixer {x: min, y: max}
    public Vector2 musicVolBounds = new Vector2(-80, 0);
    public Vector2 effectsVolBounds = new Vector2(-80, 0);

    public const string musicVolParamName = "MusicVolume";
    public const string effectsVolParamName = "EffectsVolume";
    public const string masterVolParamName = "MasterVolume";

    public Image buttonMute;
    public Sprite onMuteSprite;
    public Sprite offMuteSprite;

    public Slider volumeSlider;
    public Toggle effectsToggle;
    public Toggle musicToggle;

    private bool mute = false;

    void Start()
    {
        float effectVolume = PlayerPrefs.GetFloat(effectsVolParamName, effectsVolBounds.y);              // load volume preferences
        float musicVolume = PlayerPrefs.GetFloat(musicVolParamName, musicVolBounds.y);
        float masterVolume = PlayerPrefs.GetFloat(masterVolParamName, masterVolBounds.y);

        mixer.audioMixer.SetFloat(effectsVolParamName, effectVolume);                           // set volume preferences
        mixer.audioMixer.SetFloat(musicVolParamName, musicVolume);
        mixer.audioMixer.SetFloat(masterVolParamName, masterVolume);

        UpdateEffectsToggle(effectVolume);                                                      // update sound components view
        UpdateMusicToggle(musicVolume);
        UpdateVolumeSlider(masterVolume);
        UpdateMuteToggle(masterVolume);
    }

    /// <summary>
    /// Method toggles activity of effects mixer
    /// </summary>
    /// <param name="enabled"> { true: enable, false: disable } </param>
    public void EffectsToggle(bool enabled)
    {
        float volume = enabled ? effectsVolBounds.y : effectsVolBounds.x;             // calculate volume
        mixer.audioMixer.SetFloat(effectsVolParamName, volume);                     // change volume in mixer
        PlayerPrefs.SetFloat(effectsVolParamName, volume);                          // store preference
    }

    /// <summary>
    ///  Method toggles activity of music mixer
    /// </summary>
    /// <param name="enabled"> { true: enable, false: disable } </param>
    public void MusicToggle(bool enabled)
    {
        float volume = enabled ? musicVolBounds.y : musicVolBounds.x;
        mixer.audioMixer.SetFloat(musicVolParamName, volume);
        PlayerPrefs.SetFloat(musicVolParamName, volume);
    }

    /// <summary>
    /// Method changes volume of master mixer
    /// </summary>
    /// <param name="volume"> volume value </param>
    public void ChangeVolume(float volume)
    {
        volume = Mathf.Lerp(masterVolBounds.x, masterVolBounds.y, volume);
        mixer.audioMixer.SetFloat(masterVolParamName, volume);
        PlayerPrefs.SetFloat(masterVolParamName, volume);

        UpdateMuteToggle(volume);
    }

    /// <summary>
    ///  Method toggles activity of master mixer
    /// </summary>
    public void MuteToggle()
    {
        float volume = !mute ? masterVolBounds.x : masterVolBounds.y;
        mixer.audioMixer.SetFloat(masterVolParamName, volume);
        PlayerPrefs.SetFloat(masterVolParamName, volume);

        UpdateMuteToggle(volume);                                                       // update view of mute toggler
        UpdateVolumeSlider(volume);                                                     // update view of volume slider                               
    }

    /// <summary>
    /// Method updates view of effects toggler
    /// </summary>
    /// <param name="volume"> value volume </param>
    public void UpdateEffectsToggle(float volume)
    {
        ;
        if (effectsToggle)
            effectsToggle.isOn = volume >= midVolume(effectsVolBounds.x, effectsVolBounds.y);
    }

    /// <summary>
    /// Method updates view of music toggler
    /// </summary>
    /// <param name="volume"> value volume </param>
    public void UpdateMusicToggle(float volume)
    {
        if (musicToggle)
            musicToggle.isOn = volume >= midVolume(musicVolBounds.x, musicVolBounds.y);
    }

    /// <summary>
    /// Method updates view of volume slider
    /// </summary>
    /// <param name="volume"> value volume </param>
    public void UpdateVolumeSlider(float volume)
    {
        if (volumeSlider)
            volumeSlider.value = Mathf.InverseLerp(masterVolBounds.x, masterVolBounds.y, volume);
    }

    /// <summary>
    /// Method updates view of mute toggler
    /// </summary>
    /// <param name="volume"> value volume </param>
    public void UpdateMuteToggle(float volume)
    {
        mute = volume == masterVolBounds.x;
        if (buttonMute != null && onMuteSprite != null && offMuteSprite != null)
            buttonMute.sprite = mute ? onMuteSprite : offMuteSprite;
    }

    private static float midVolume(float minVolume, float maxVolume)
    {
        return maxVolume - (maxVolume - minVolume) / 2;
    }
}
