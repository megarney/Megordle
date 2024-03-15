using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Options
 * 1/4/2024
 * Attached to the Options scene
 * Allows the user to toggle the music and sound effects on or off
 * TODO: actually toggle the music and sound effects, just changes icon for now
 */

public class Options : MonoBehaviour
{
    /*
     * Method for the main menu button
     */
    public void returnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Reset()
    {soundEffectsBtn.image.sprite = soundEffectsOn;

        MusicBtn.image.sprite = MusicOn;
        if (PlayerPrefs.HasKey("MusicPref"))
        {
            if (PlayerPrefs.GetString("MusicPref").Equals("Off"))
            {
                Music.Instance.ToggleMusic();
            }
        }

        //UsedWords.reset();
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("Megash", 0);

        WordSelection.clearLists();
    }

    [SerializeField] private Sprite soundEffectsOn;
    [SerializeField] private Sprite soundEffectsOff;

    [SerializeField] private Button soundEffectsBtn;

    /*
     * Allows for the sprites to stay in their on or off stages when Options is closed
     */
    private void Awake()
    {
        if (PlayerPrefs.HasKey("soundEffectsPref"))
        {
            if (PlayerPrefs.GetString("soundEffectsPref").Equals("On"))
            {
                soundEffectsBtn.image.sprite = soundEffectsOn;
                PlayerPrefs.SetString("soundEffectsPref", "On");
            }
            else
            {
                soundEffectsBtn.image.sprite = soundEffectsOff;
                PlayerPrefs.SetString("soundEffectsPref", "Off");
            }
        }
        else
        {
            soundEffectsBtn.image.sprite = soundEffectsOn;
            PlayerPrefs.SetString("soundEffectsPref", "On");
        }
        if (PlayerPrefs.HasKey("MusicPref"))
        {
            if (PlayerPrefs.GetString("MusicPref").Equals("On"))
            {
                MusicBtn.image.sprite = MusicOn;
                PlayerPrefs.SetString("MusicPref", "On");
            }
            else
            {
                MusicBtn.image.sprite = MusicOff;
                PlayerPrefs.SetString("MusicPref", "Off");
            }
        }
        else
        {
            MusicBtn.image.sprite = MusicOn;
            PlayerPrefs.SetString("MusicPref", "On");
        }
    }

    /*
     * Toggles the sound effects sprite;
     */
    public void toggleSoundEffects()
    {
        if (PlayerPrefs.HasKey("soundEffectsPref"))
        {
            if (PlayerPrefs.GetString("soundEffectsPref").Equals("On"))
            {
                soundEffectsBtn.image.sprite = soundEffectsOff;
                PlayerPrefs.SetString("soundEffectsPref", "Off");
            }
            else
            {
                soundEffectsBtn.image.sprite = soundEffectsOn;
                PlayerPrefs.SetString("soundEffectsPref", "On");
            }
        }
        else
        {
            soundEffectsBtn.image.sprite = soundEffectsOff;
            PlayerPrefs.SetString("soundEffectsPref", "Off");
        }
    }

    [SerializeField] private Sprite MusicOn;
    [SerializeField] private Sprite MusicOff;

    [SerializeField] private Button MusicBtn;

    /*
     * Toggles the music sprite
     */
    public void toggleMusic()
    {
        if (PlayerPrefs.HasKey("MusicPref"))
        {
            if (PlayerPrefs.GetString("MusicPref").Equals("On"))
            {
                MusicBtn.image.sprite = MusicOff;
                PlayerPrefs.SetString("MusicPref", "Off");
            }
            else
            {
                MusicBtn.image.sprite = MusicOn;
                PlayerPrefs.SetString("MusicPref", "On");
            }
        }
        else
        {
            MusicBtn.image.sprite = MusicOff;
            PlayerPrefs.SetString("MusicPref", "Off");
        }
    }
}
