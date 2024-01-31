using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * BuyAttempt
 * 1/4/2024
 * Attached to the Buy Attempt scene
 * Defines the methods for the buttons in its scene
 */

public class BuyAttempt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI megashText;

    void Start()
    {
        megashText.text = Megash.getTotalCash().ToString();
    }

    public static string scene;

    public static void SetScene(string sc)
    {
        scene = sc;
    }

    /*
     * If the user clicks on the house icon, they are directed to the main men
     */
    public void giveUp() { 
        SceneManager.LoadSceneAsync("Fail");
    }

    /*
     * If the user clicks on the Yes! button, subtracts 50 from their Megash
     * TODO: Direct the user back to the Lev#Diff# scene
     */
    public void oneMoreTry()
    {
        Attempt.SetAttempts(1);

        PlayerPrefs.SetInt("Megash", (PlayerPrefs.GetInt("Megash")) - 50);
        SceneManager.LoadSceneAsync(scene);
    }
}
