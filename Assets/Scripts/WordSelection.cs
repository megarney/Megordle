using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class WordSelection : MonoBehaviour
{

    [SerializeField] private TextAsset fiveLetterWords;
    [SerializeField] private TextAsset eightLetterWords;
    [SerializeField] private TextAsset twelveLetterWords;

    private static List<string> fiveLetterList = new List<string>();
    private static List<string> eightLetterList = new List<string>();
    private static List<string> twelveLetterList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        //FIVE
        if (!PlayerPrefs.HasKey("FiveLetterList"))
        {
            PlayerPrefs.SetString("FiveLetterList", fiveLetterWords.text);
            string[] fiveWordList = PlayerPrefs.GetString("FiveLetterList").Split(',');
            foreach (string word in fiveWordList)
            {
                fiveLetterList.Add(word);
            }
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
        else if(PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("FiveAvail") != 0)
        {
            string[] fiveWordList = PlayerPrefs.GetString("FiveLetterList").Split(',');
            foreach (string word in fiveWordList)
            {
                fiveLetterList.Add(word);
            }
            fiveLetterList.RemoveAt(fiveLetterList.Count - 1); //removes blank
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
        //EIGHT
        if (!PlayerPrefs.HasKey("EightLetterList"))
        {
            PlayerPrefs.SetString("EightLetterList", eightLetterWords.text);
            string[] eightWordList = PlayerPrefs.GetString("EightLetterList").Split(',');
            foreach (string word in eightWordList)
            {
                eightLetterList.Add(word);
            }
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
        else if (PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("EightAvail") != 0)
        {
            string[] eightWordList = PlayerPrefs.GetString("EightLetterList").Split(',');
            foreach (string word in eightWordList)
            {
                eightLetterList.Add(word);
            }
            eightLetterList.RemoveAt(eightLetterList.Count - 1); //removes blank
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
        //TWELVE
        if (!PlayerPrefs.HasKey("TwelveLetterList"))
        {
            PlayerPrefs.SetString("TwelveLetterList", twelveLetterWords.text);
            string[] twelveWordList = PlayerPrefs.GetString("TwelveLetterList").Split(',');
            foreach (string word in twelveWordList)
            {
                twelveLetterList.Add(word);
            }
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
        else if (PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("TwelveAvail") != 0)
        {
            string[] twelveWordList = PlayerPrefs.GetString("TwelveLetterList").Split(',');
            foreach (string word in twelveWordList)
            {
                twelveLetterList.Add(word);
            }
            twelveLetterList.RemoveAt(twelveLetterList.Count - 1); //removes blank
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
            PlayerPrefs.SetInt("hasRun", 1);
        }
    }

    public static void clearLists()
    {
        fiveLetterList.Clear();
        eightLetterList.Clear();
        twelveLetterList.Clear();
    }

    public static void SelectAnswer(int level)
    {
        string answer = "";

        var rand = new System.Random();
        int n = 0;
        if(level == 1)
        {
            n = rand.Next(0, fiveLetterList.Count);
            answer = fiveLetterList[n];
            fiveLetterList.RemoveAt(n);
            Debug.Log(fiveLetterList.Count);
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
        }
        else if(level == 2)
        {
            n = rand.Next(0, eightLetterList.Count);
            answer = eightLetterList[n];
            eightLetterList.RemoveAt(n);
            Debug.Log(eightLetterList.Count);
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
        }
        else if(level == 3)
        {
            n = rand.Next(0, twelveLetterList.Count);
            answer = twelveLetterList[n];
            twelveLetterList.RemoveAt(n);
            Debug.Log(twelveLetterList.Count);
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
        }
        Game.SetAnswer(answer);
    }

    /*
     * Adds extra letters to the word depending on difficulty
     *      Difficulty 1 => + 0
     *      Difficulty 2 => + 1
     *      Difficulty 3 => + 2
     * Checks to make sure none of the extra letters are r, d, y, or s
     *      Helps prevents making a longer word
     * Calls SetAddedAnswer in Game to set the added answer
     */
    public static void extraLetters(int difficulty)
    {
        string extra = "";
        string addedAnswer = Game.GetAnswer();
        int numAdded = difficulty - 1;
        var rand = new System.Random();
        char c;
        int num;

        for (int i = 1; i <= numAdded; i++)
        {
            num = rand.Next(0, 26);
            c = (char)('a' + num);
            if (c == 'r' || c == 'd' || c == 'y' || c == 's')
            {
                extraLetters(difficulty);
            }
            extra += c;
        }
        addedAnswer += extra.ToLower();
        Game.SetAddedAnswer(addedAnswer);
    }

    public static void saveList()
    {
        //FIVE
        string fiveSaved = "";
        foreach (string word in fiveLetterList)
        {
            if (word != "")
            {
                fiveSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("FiveLetterList", fiveSaved);
        PlayerPrefs.SetInt("hasRun", 0);
        //EIGHT
        string eightSaved = "";
        foreach (string word in eightLetterList)
        {
            if (word != "")
            {
                eightSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("EightLetterList", eightSaved);
        PlayerPrefs.SetInt("hasRun", 0);
        //TWELVE
        string twelveSaved = "";
        foreach (string word in twelveLetterList)
        {
            if (word != "")
            {
                twelveSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("TwelveLetterList", twelveSaved);
        PlayerPrefs.SetInt("hasRun", 0);
    }
}
