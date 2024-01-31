using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Buttons : MonoBehaviour
{
    [SerializeField] private AudioSource effectSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void onBtnClick()
    {

        if (PlayerPrefs.HasKey("soundEffectsPref"))
        {
            if (PlayerPrefs.GetString("soundEffectsPref").Equals("On"))
            {
                effectSource.Play();
            }
        }
        else
        {
            PlayerPrefs.SetString("soundEffectsPref", "On");
            effectSource.Play();
        }
    }
}
