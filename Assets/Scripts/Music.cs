using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * Music
 * 1/3/2024
 * Attached to the main menu scene
 * Plays music and is called so that it can play music throughout all the scenes without restarting or stacking
 */

public class Music : MonoBehaviour
{
    public static Music Instance;

    [SerializeField] private AudioSource _musicSource;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if(PlayerPrefs.GetString("MusicPref").Equals("Off") && !_musicSource.mute)
        {
            ToggleMusic();
        }
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
        if(_musicSource.mute)
        {
            PlayerPrefs.SetString("MusicPref", "Off");
        }
        else
        {
            PlayerPrefs.SetString("MusicPref", "On");
        }
    }
}
