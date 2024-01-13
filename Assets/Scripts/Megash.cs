using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Megash
 * 1/5/2024
 * Keeps track of the player's total cash using PlayerPrefs and the player's cash earned in one game
 */

public class Megash : MonoBehaviour
{
    private static int cash;

    /*
     * Resets the player's current cash to 0 at the beginning of a game
     */
    public static void newGame()
    {
        cash = 0;
    }

    /*
     * Returns the player's total cash
     */
    public static int getTotalCash()
    {
        if (PlayerPrefs.HasKey("Megash"))
        {
            return PlayerPrefs.GetInt("Megash");
        }
        else
        {
            PlayerPrefs.SetInt("Megash", 0);
            return 0;
        }
    }

    public static void setTotalCash(int startTotal)
    {
        PlayerPrefs.SetInt("Megash", startTotal);
    }

    public static int getCash()
    {
        return cash;
    }

    /*
     * Calculates the player's cash for that round based on the amount of points they earned
     *      1 cash for every 10 points
     * Adds the cash to the total cash
     */
    public static void calculateCash()
    {
        cash = Points.getPoints() / 10;
        if (PlayerPrefs.HasKey("Megash"))
        {
            PlayerPrefs.SetInt("Megash", (PlayerPrefs.GetInt("Megash")) + cash);
        }
        else
        {
            PlayerPrefs.SetInt("Megash", cash);
        }
    }

    /*
     * Spends the player's Megash if the player can afford it
     * If they can't, returns false
     */
    public static bool spendCash(int spend)
    {
        if(spend > PlayerPrefs.GetInt("Megash"))
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("Megash", (PlayerPrefs.GetInt("Megash")) - spend);
            return true;
        }
    }

    public static void spend(int spend)
    {
        PlayerPrefs.SetInt("Megash", (PlayerPrefs.GetInt("Megash")) - spend);
    }

    /*
     * Determines whether or not the player can afford something
     *      Doesn't spend it
     */
    public static bool canSpend(int spend)
    {
        if (spend > PlayerPrefs.GetInt("Megash"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
