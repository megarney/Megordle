using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * Fail
 * 1/4/2024
 * Attached to the Fail scene
 * Shown when the player fails a round
 * Shows the player what the answer was and lets them go back to the main menu or play again
 */

public class Fail : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AnswerText;

    /*
     * Shows the user what the answer was
     * Loses the users streak by calling Streak
     */
    void Start()
    {
        AnswerText.text = Game.GetAnswer();
        Streak.loseStreak();
        int level = Game.GetLevel();
        if(level == 1 )
        {
            PlayerPrefs.SetInt("LevelOne", 0);
        }
        else if(level == 2 )
        {
            PlayerPrefs.SetInt("LevelTwo", 0);
        }
        else if (level == 3 )
        {
            PlayerPrefs.SetInt("LevelThree", 0);
        }
    }

    /*
     * Method for the main menu button
     */
    public void toMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    /*
     * Method for the play again button
     */
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level Select");
    }
}
