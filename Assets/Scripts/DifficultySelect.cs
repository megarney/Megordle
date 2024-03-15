using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * DifficultySelect
 * 1/2/2024
 * Attached to the Difficulty Select scene
 * Allows the user to select the difficulty of the round
 */

public class DifficultySelect : MonoBehaviour
{

    /*
     * Method for the return button
     */
    public void returnToLevelSelect()
    {
        SceneManager.LoadSceneAsync("Level Select");
    }

    /*
     * Method for the main menu button
     */
    public void returnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    /*
     * Method for the help button
     */
    public static void toHelp()
    {
        Help.SetScene("Difficulty Select");
        SceneManager.LoadSceneAsync("Help");
    }

    /*
     * Sets the difficulty in Game
     * Adds extra letters in SelectWord
     * Creates the Megordle in Game
     * Sets the total number of points possible in Points
     * Directs the user to their game depending on their level
     */
    public static void DifficultyOne()
    {
        Game.SetDifficulty(1);
        WordSelection.extraLetters(1);
        Game.Scramble();
        Points.points();

        int level = Game.GetLevel();
        if(level == 1)
        {
            PlayerPrefs.SetInt("LevelOneDiff", 1);
            SceneManager.LoadSceneAsync("Lev1Diff1");
        }
        else if(level == 2)
        {
            PlayerPrefs.SetInt("LevelTwoDiff", 1);
            SceneManager.LoadSceneAsync("Lev2Diff1");
        }
        else if(level == 3)
        {
            PlayerPrefs.SetInt("LevelThreeDiff", 1);
            SceneManager.LoadSceneAsync("Lev3Diff1");
        }
    }

    public static void DifficultyTwo()
    {
        Game.SetDifficulty(2);
        WordSelection.extraLetters(2);
        Game.Scramble();
        Points.points();

        int level = Game.GetLevel();
        if (level == 1)
        {
            PlayerPrefs.SetInt("LevelOneDiff", 2);
            SceneManager.LoadSceneAsync("Lev1Diff2");
        }
        else if (level == 2)
        {
            PlayerPrefs.SetInt("LevelTwoDiff", 2);
            SceneManager.LoadSceneAsync("Lev2Diff2");
        }
        else if (level == 3)
        {
            PlayerPrefs.SetInt("LevelThreeDiff", 2);
            SceneManager.LoadSceneAsync("Lev3Diff2");
        }
    }

    public static void DifficultyThree()
    {
        Game.SetDifficulty(3);
        WordSelection.extraLetters(3);
        Game.Scramble();
        Points.points();

        int level = Game.GetLevel();
        if (level == 1)
        {
            PlayerPrefs.SetInt("LevelOneDiff", 3);
            SceneManager.LoadSceneAsync("Lev1Diff3");
        }
        else if (level == 2)
        {
            PlayerPrefs.SetInt("LevelTwoDiff", 3);
            SceneManager.LoadSceneAsync("Lev2Diff3");
        }
        else if (level == 3)
        {
            PlayerPrefs.SetInt("LevelThreeDiff", 3);
            SceneManager.LoadSceneAsync("Lev3Diff3");
        }
    }
}
