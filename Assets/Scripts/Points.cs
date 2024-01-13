using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Points
 * 1/5/2024
 * Keeps track of the users points during a game
 */

public class Points : MonoBehaviour
{
    private static int totalPoints;

    /*
     * Called at the start of a game and determines the total amount of points possible
     *      Calls streakMultiplier() in Streak
     *      Calls getDifMult()
     *      Calls getLevMult()
     */
    public static void points()
    {
        totalPoints = 100 + Streak.streakMultiplier() + getDifMult() + getLevMult();
    }

    public static int getPoints()
    {
        if(totalPoints >= 0)
        {
            return totalPoints;
        }
        else
        {
            return 0;
        }
    }

    /*
     * Determines the difficulty multiplier
     *      Difficulty 1 => + 0
     *      Difficulty 2 => + 10
     *      Difficulty 3 => + 20
     */
    public static int getDifMult()
    {
        int difficulty = Game.GetDifficulty();
        if(difficulty == 1 )
        {
            return 0;
        }
        else if( difficulty == 2 )
        {
            return 10;
        }
        else if ( difficulty == 3)
        {
            return 20;
        }
        return 0;
    }

    /*
     * Determines the level multiplier
     *      Level 1 => + 0
     *      Level 2 => + 50
     *      Level 3 => + 100
     */
    public static int getLevMult()
    {
        int level = Game.GetLevel();
        if (level == 1)
        {
            return 0;
        }
        else if (level == 2)
        {
            return 50;
        }
        else if (level == 3)
        {
            return 100;
        }
        return 0;
    }

    /*
     * Subtracts 10 points when the player fails a guess
     */
    public static void failedAttempt()
    {
        totalPoints -= 10;
    }

}
