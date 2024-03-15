using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

/*
 * Main Menu
 * 1/2/2024
 * Attached to the Main Menu scene
 * Contains the methods for all the buttons in the Main Menu scene
 */

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI megashText;

    /*
     * Displays the user's total Megash
     */
    public void Start()
    {
        //UsedWords.loadList();
        megashText.text = Megash.getTotalCash().ToString();
    }

    /*
     * Method for the play button
     */
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level Select");
    }

    /*
     * Method for the help button
     */
    public void toHelp()
    {
        Help.SetScene("Main Menu");
        SceneManager.LoadSceneAsync("Help");
    }

    /*
     * Method for the options button
     */
    public void Options()
    {
        SceneManager.LoadSceneAsync("Options");
    }

    /*
     * Method for the exit button
     */
    public void ExitGame()
    {
        WordSelection.saveList();
        Application.Quit();
    }


}
