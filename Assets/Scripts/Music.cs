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
    [SerializeField] private AudioSource backgroundMusic;

    /*
     * Starts the music when the player first opens up the game
     */
    private void Awake()
    {
        Music[] objects = FindObjectsOfType<Music>();

        if (objects.Length > 1)
        {
            Destroy(objects[1].gameObject);
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
        backgroundMusic = GetComponent<AudioSource>();
    }

    /*
     * Called by different scenes so that music can continue
     * DOESN'T ACTUALLY DO ANYTHING
     * TODO: Change so that the scenes will only play music if the user's preferences are set for that
     */
    public void PlayMusic()
    {
        if (backgroundMusic.isPlaying) return;
        backgroundMusic.Play();
    }
}
