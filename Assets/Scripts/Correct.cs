using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
* Correct
* 1/4/2024
* Attached to the Correct scene
* Displays the player's points and cash earned during that round, total Megash, streak, 
* and how many points they earned from their streak bonus
*/

public class Correct : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsEarnedText;
    [SerializeField] private TextMeshProUGUI megashEarnedText;
    [SerializeField] private TextMeshProUGUI megashTotalText;
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField] private TextMeshProUGUI streakMultiplierText;

    /*
    * Calls Megash to calculate the amount of Megash the player earned and their new total
    * Uses PlayerPrefs to display the users relevant statistics
    */
    void Start()
    {
        WordSelection.removeWord(Game.GetAnswer());
        WordSelection.resetWord();

        Megash.calculateCash();
        
        pointsEarnedText.text = Points.getPoints().ToString();
        megashEarnedText.text = Megash.getCash().ToString();
        megashTotalText.text = PlayerPrefs.GetInt("Megash").ToString();
        streakText.text = PlayerPrefs.GetInt("Streak").ToString();
        streakMultiplierText.text = "+" + (Streak.streakMultiplier() - 10).ToString() + " points";
        
        int level = Game.GetLevel();
        if (level == 1)
        {
            PlayerPrefs.SetInt("LevelOne", 0);
        }
        else if (level == 2)
        {
            PlayerPrefs.SetInt("LevelTwo", 0);
        }
        else if (level == 3)
        {
            PlayerPrefs.SetInt("LevelThree", 0);
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
     * Method for the play again button
     */
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level Select");
    }
}
