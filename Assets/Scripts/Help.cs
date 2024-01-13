using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Help
 * 1/3/2024
 * Attached to the Help and all sub Help scenes
 * Contains the methods for all of the help scenes
 */

public class Help : MonoBehaviour
{

    /*
     * Keeps track of which scene the user came from so they can return to that scene when they are done
     */
    public static string scene;

    public static void SetScene(string sc)
    {
        scene = sc;
    }

    public static void toPrev()
    {
        SceneManager.LoadSceneAsync(scene);
    }

    /*
     * The methods for all of the help scene buttons
     */
    public void returnToHelp()
    {
        SceneManager.LoadSceneAsync("Help");
    }

    public void returnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void toLevels()
    {
        SceneManager.LoadSceneAsync("LevelsHelp");
    }

    public void toDifficulty()
    {
        SceneManager.LoadSceneAsync("DifficultyHelp");
    }

    public void toPoints()
    {
        SceneManager.LoadSceneAsync("PointsHelp");
    }

    public void toGuessing()
    {
        SceneManager.LoadSceneAsync("GuessingHelp");
    }

    public void toAttempts()
    {
        SceneManager.LoadSceneAsync("AttemptsHelp");
    }

    public void toMegash()
    {
        SceneManager.LoadSceneAsync("MegashHelp");
    }

    public void toMarket()
    {
        SceneManager.LoadSceneAsync("MarketHelp");
    }

}
