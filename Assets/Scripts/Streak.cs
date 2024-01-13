using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Streak
 * 1/5/2024
 * Keeps track of the amount of games the player has won in a row using PlayerPrefs
 */

public class Streak : MonoBehaviour
{
    /*
     * Increases the player's streak by 1
     * Called when a player wins a game
     */
    public static void increaseStreak()
    {
        if (PlayerPrefs.HasKey("Streak"))
        {
            PlayerPrefs.SetInt("Streak", PlayerPrefs.GetInt("Streak") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Streak", 1);
        }
    }

    /*
     * Sets the player's streak to 0
     * Called when a player fails a game
     */
    public static void loseStreak()
    {
        PlayerPrefs.SetInt("Streak", 0);
    }

    /*
     * Calculates the player's streak multiplier
     * Called in Points when determining the player's total possible points
     */
    public static int streakMultiplier()
    {
        if (PlayerPrefs.HasKey("Streak"))
        {
            return PlayerPrefs.GetInt("Streak") * 10;
        }
        else
        {
            PlayerPrefs.SetInt("Streak", 0);
            return 0;
        }
    }
}
