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

    private static List<string> fiveLetterFail = new List<string>();
    private static List<string> eightLetterFail = new List<string>();
    private static List<string> twelveLetterFail = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        //FIVE AVAIL
        if (!PlayerPrefs.HasKey("FiveLetterList"))
        {
            PlayerPrefs.SetString("FiveLetterList", fiveLetterWords.text);
            string[] fiveWordList = PlayerPrefs.GetString("FiveLetterList").Split(',');
            foreach (string word in fiveWordList)
            {
                fiveLetterList.Add(word);
            }
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
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
        }
        //EIGHT AVAIL
        if (!PlayerPrefs.HasKey("EightLetterList"))
        {
            PlayerPrefs.SetString("EightLetterList", eightLetterWords.text);
            string[] eightWordList = PlayerPrefs.GetString("EightLetterList").Split(',');
            foreach (string word in eightWordList)
            {
                eightLetterList.Add(word);
            }
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
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
        }
        //TWELVE AVAIL
        if (!PlayerPrefs.HasKey("TwelveLetterList"))
        {
            PlayerPrefs.SetString("TwelveLetterList", twelveLetterWords.text);
            string[] twelveWordList = PlayerPrefs.GetString("TwelveLetterList").Split(',');
            foreach (string word in twelveWordList)
            {
                twelveLetterList.Add(word);
            }
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
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
        }
        //FIVE FAIL
        if (PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("FiveFail") != 0)
        {
            string[] fiveWordFail = PlayerPrefs.GetString("FiveLetterFail").Split(',');
            foreach (string word in fiveWordFail)
            {
                fiveLetterFail.Add(word);
            }
            fiveLetterFail.RemoveAt(fiveLetterFail.Count - 1); //removes blank
            PlayerPrefs.SetInt("FiveFail", fiveLetterFail.Count);
        }
        //EIGHT FAIL
        if (PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("EightFail") != 0)
        {
            string[] eightWordFail = PlayerPrefs.GetString("EightLetterFail").Split(',');
            foreach (string word in eightWordFail)
            {
                eightLetterFail.Add(word);
            }
            eightLetterFail.RemoveAt(eightLetterFail.Count - 1); //removes blank
            PlayerPrefs.SetInt("EightFail", eightLetterFail.Count);
        }
        //Twelve FAIL
        if (PlayerPrefs.GetInt("hasRun") == 0 && PlayerPrefs.GetInt("TwelveFail") != 0)
        {
            string[] twelveWordFail = PlayerPrefs.GetString("TwelveLetterFail").Split(',');
            foreach (string word in twelveWordFail)
            {
                twelveLetterFail.Add(word);
            }
            twelveLetterFail.RemoveAt(twelveLetterFail.Count - 1); //removes blank
            PlayerPrefs.SetInt("TwelveFail", twelveLetterFail.Count);
        }
        //hasRun bool
        if (PlayerPrefs.GetInt("hasRun") == 0)
        {
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
        }
        else if(level == 2)
        {
            n = rand.Next(0, eightLetterList.Count);
            answer = eightLetterList[n];
        }
        else if(level == 3)
        {
            n = rand.Next(0, twelveLetterList.Count);
            answer = twelveLetterList[n];
        }
        Game.SetAnswer(answer);
    }

    public static void removeWord(string word)
    {
        if(word.Length == 5)
        {
            fiveLetterList.RemoveAt(fiveLetterList.IndexOf(word));
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
        }
        else if (word.Length == 8)
        {
            eightLetterList.RemoveAt(eightLetterList.IndexOf(word));
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
        }
        else if (word.Length == 12)
        {
            twelveLetterList.RemoveAt(twelveLetterList.IndexOf(word));
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
        }
    }

    public static void fail(string word)
    {
        if (word.Length == 5)
        {
            fiveLetterFail.Add(word);
            PlayerPrefs.SetInt("FiveFail", fiveLetterFail.Count);
        }
        else if (word.Length == 8)
        {
            eightLetterFail.Add(word);
            PlayerPrefs.SetInt("EightFail", eightLetterFail.Count);
        }
        else if (word.Length == 12)
        {
            twelveLetterFail.Add(word);
            PlayerPrefs.SetInt("TwelveFail", twelveLetterFail.Count);
        }
    }

    public static void resetWord()
    {
        if(PlayerPrefs.GetInt("FiveAvail") == 0 && PlayerPrefs.GetInt("FiveFail") != 0)
        {
            fiveLetterList.Clear();
            foreach (string word in fiveLetterFail)
            {
                fiveLetterList.Add(word);
            }
            fiveLetterFail.Clear();
            PlayerPrefs.SetInt("FiveAvail", fiveLetterList.Count);
        }
        if (PlayerPrefs.GetInt("EightAvail") == 0 && PlayerPrefs.GetInt("EightFail") != 0)
        {
            eightLetterList.Clear();
            foreach (string word in eightLetterFail)
            {
                eightLetterList.Add(word);
            }
            eightLetterFail.Clear();
            PlayerPrefs.SetInt("EightAvail", eightLetterList.Count);
        }
        if (PlayerPrefs.GetInt("TwelveAvail") == 0 && PlayerPrefs.GetInt("TwelveFail") != 0)
        {
            twelveLetterList.Clear();
            foreach (string word in twelveLetterFail)
            {
                twelveLetterList.Add(word);
            }
            twelveLetterFail.Clear();
            PlayerPrefs.SetInt("TwelveAvail", twelveLetterList.Count);
        }
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
        //FIVE AVAIL
        string fiveSaved = "";
        foreach (string word in fiveLetterList)
        {
            if (word != "")
            {
                fiveSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("FiveLetterList", fiveSaved);
        //EIGHT AVAIL
        string eightSaved = "";
        foreach (string word in eightLetterList)
        {
            if (word != "")
            {
                eightSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("EightLetterList", eightSaved);
        //TWELVE AVAIL
        string twelveSaved = "";
        foreach (string word in twelveLetterList)
        {
            if (word != "")
            {
                twelveSaved += word + ",";
            }
        }
        PlayerPrefs.SetString("TwelveLetterList", twelveSaved);
        //FIVE FAIL
        string fiveFail = "";
        foreach(string word in fiveLetterFail)
        {
            if(word != "")
            {
                fiveFail += word + ",";
            }
        }
        PlayerPrefs.SetString("FiveLetterFail", fiveFail);
        //EIGHT FAIL
        string eightFail = "";
        foreach (string word in eightLetterFail)
        {
            if (word != "")
            {
                eightFail += word + ",";
            }
        }
        PlayerPrefs.SetString("EightLetterFail", eightFail);
        //TWELVE FAIL
        string twelveFail = "";
        foreach (string word in twelveLetterFail)
        {
            if (word != "")
            {
                twelveFail += word + ",";
            }
        }
        PlayerPrefs.SetString("TwelveLetterFail", twelveFail);
        PlayerPrefs.SetInt("hasRun", 0);
    }
}
