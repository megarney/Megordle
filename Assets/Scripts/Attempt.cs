using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Attempt:
 * 1/4/2024
 * Keeps track of the number of attempts in each game
 */

public class Attempt : MonoBehaviour
{
    private static int attempts; 
    private static int wordLength;

    /*
     * Sets the number of attempts
     * Called when the level is selected
     */
    public static void SetAttempts()
    {
        wordLength = Game.GetAnswer().Length;
        if (wordLength == 5)
        {
            attempts = 4;
        }
        else if (wordLength == 8)
        {
            attempts = 6;
        }
        else if (wordLength == 12)
        {
            attempts = 8;
        }
    }

    public static void SetAttempts(int attempt)
    {
        attempts = attempt;
    }

    public static int GetAttempts()
    {
        return attempts;
    }

    /*
     * Sets the number of attempts to 1
     * Called in BuyAttempt when the player choses to spend 50 Megash for one more attempt
     */
    public static void oneMoreAttempt()
    {
        attempts = 1;
    }

    /*
     * Reduces the number of attempts when the player fails a guess
     * Called in the Lev#Diff# 's failedAttempt() method
     */
    public static int failedAttempt()
    {
        attempts--;
        return attempts;
    }
}
