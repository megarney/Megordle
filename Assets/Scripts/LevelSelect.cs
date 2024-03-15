using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * LevelSelect
 * 1/2/2024
 * Attached to the Level Select scene
 * Allows the player to select a level for their game
 */

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelOneText;
    [SerializeField] private TextMeshProUGUI levelTwoText;
    [SerializeField] private TextMeshProUGUI levelThreeText;

    [SerializeField] private Button levelOneButton;
    [SerializeField] private Button levelTwoButton;
    [SerializeField] private Button levelThreeButton;

    /*
     * Allows the music to continue playing during this scene
     * If there are no more words left for a certain level,
     *      calls the level's outOf method
     */
    public void Awake()
    {

        int fiveAvail = PlayerPrefs.GetInt("FiveAvail");
        int eightAvail = PlayerPrefs.GetInt("EightAvail");
        int twelveAvail = PlayerPrefs.GetInt("TwelveAvail");

        //int fiveAvailable = UsedWords.getFiveAvailable();
        //int eightAvailable = UsedWords.getEightAvailable();
        //int twelveAvailable = UsedWords.getTwelveAvailable();

        if (PlayerPrefs.GetInt("LevelOne") == 1)
        {
            levelOneText.text = "Continue";
            levelOneButton.onClick.AddListener(continueLevelOne);
        }
        else if (fiveAvail == 0)
        {
            outOfLevelOne();
        }
        else
        {
            levelOneButton.onClick.AddListener(LevelOne);
        }

        if (PlayerPrefs.GetInt("LevelTwo") == 1)
        {
            levelTwoText.text = "Continue";
            levelTwoButton.onClick.AddListener(continueLevelTwo);
        }
        else if (eightAvail == 0)
        {
            outOfLevelTwo();
        }
        else
        {
            levelTwoButton.onClick.AddListener(LevelTwo);
        }

        if (PlayerPrefs.GetInt("LevelThree") == 1)
        {
            levelThreeText.text = "Continue";
            levelThreeButton.onClick.AddListener(continueLevelThree);
        }
        else if (twelveAvail == 0)
        {
            outOfLevelThree();
        }
        else
        {
            levelThreeButton.onClick.AddListener(LevelThree);
        }
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
        Help.SetScene("Level Select");
        SceneManager.LoadSceneAsync("Help");
    }

    /*
     * Sets the level in Game
     * Selects the word in SelectWord
     * Sets the number of attempts in Attempt
     * Sets the wordle in Game
     * Directs the user to the Difficulty Select scene
     */
    public static void LevelOne()
    {
        Game.SetLevel(1);
        WordSelection.SelectAnswer(1);
        Attempt.SetAttempts();
        Game.SetWordle();
        SceneManager.LoadSceneAsync("Difficulty Select");
    }

    /*
     * Disables the button for the level
     * Displays 'Complete' instead of 'Level #'
     */
    public void outOfLevelOne()
    {
        levelOneButton.interactable = false;
        levelOneText.text = "Complete";
    }

    public void continueLevelOne()
    {
        Game.SetLevel(1);
        Game.SetAnswer(PlayerPrefs.GetString("LevelOneAnswer"));
        Attempt.SetAttempts(PlayerPrefs.GetInt("LevelOneAttempts"));
        Game.SetWordle(PlayerPrefs.GetString("LevelOneWordle"));
        Game.SetScrambled(PlayerPrefs.GetString("LevelOneScrambled"));
        Points.setPoints(PlayerPrefs.GetInt("LevelOnePoints"));
        int difficulty = PlayerPrefs.GetInt("LevelOneDiff");
        if (difficulty == 1)
        {
            SceneManager.LoadSceneAsync("Lev1Diff1");
        }
        else if(difficulty == 2)
        {
            SceneManager.LoadSceneAsync("Lev1Diff2");
        }
        else if (difficulty == 3)
        {
            SceneManager.LoadSceneAsync("Lev1Diff3");
        }
    }

    public static void LevelTwo()
    {
        Game.SetLevel(2);
        SelectWord.SelectAnswer(2);
        Attempt.SetAttempts();
        Game.SetWordle();
        SceneManager.LoadSceneAsync("Difficulty Select");
    }

    public void outOfLevelTwo()
    {
        levelTwoButton.interactable = false;
        levelTwoText.text = "Complete";
    }

    public void continueLevelTwo()
    {
        Game.SetLevel(2);
        Game.SetAnswer(PlayerPrefs.GetString("LevelTwoAnswer"));
        Attempt.SetAttempts(PlayerPrefs.GetInt("LevelTwoAttempts"));
        Game.SetWordle(PlayerPrefs.GetString("LevelTwoWordle"));
        Game.SetScrambled(PlayerPrefs.GetString("LevelTwoScrambled"));
        Points.setPoints(PlayerPrefs.GetInt("LevelTwoPoints"));
        int difficulty = PlayerPrefs.GetInt("LevelTwoDiff");
        if (difficulty == 1)
        {
            SceneManager.LoadSceneAsync("Lev2Diff1");
        }
        else if (difficulty == 2)
        {
            SceneManager.LoadSceneAsync("Lev2Diff2");
        }
        else if (difficulty == 3)
        {
            SceneManager.LoadSceneAsync("Lev2Diff3");
        }
    }

    public static void LevelThree()
    {
        Game.SetLevel(3);
        SelectWord.SelectAnswer(3);
        Attempt.SetAttempts();
        Game.SetWordle();
        SceneManager.LoadSceneAsync("Difficulty Select");
    }

    public void outOfLevelThree()
    {
        levelThreeButton.interactable = false;
        levelThreeText.text = "Complete";
    }

    public void continueLevelThree()
    {
        Game.SetLevel(3);
        Game.SetAnswer(PlayerPrefs.GetString("LevelThreeAnswer"));
        Attempt.SetAttempts(PlayerPrefs.GetInt("LevelThreeAttempts"));
        Game.SetWordle(PlayerPrefs.GetString("LevelThreeWordle"));
        Game.SetScrambled(PlayerPrefs.GetString("LevelThreeScrambled"));
        Points.setPoints(PlayerPrefs.GetInt("LevelThreePoints"));
        int difficulty = PlayerPrefs.GetInt("LevelThreeDiff");
        if (difficulty == 1)
        {
            SceneManager.LoadSceneAsync("Lev3Diff1");
        }
        else if (difficulty == 2)
        {
            SceneManager.LoadSceneAsync("Lev3Diff2");
        }
        else if (difficulty == 3)
        {
            SceneManager.LoadSceneAsync("Lev3Diff3");
        }
    }

}
