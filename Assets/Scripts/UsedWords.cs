using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/*
 * UsedWords
 * 1/6/2024
 * Keeps track of the words the player has already played in a Dictionary
 */

public class UsedWords : MonoBehaviour
{
    private static List<string> usedWords = new List<string>();
    private static int eightAvailable = 504; //keeps track of the amount of words left in the eight letter words database
    private static int twelveAvailable = 71; //keeps track of the amount of words left in the twelve letter words database

    private static bool dataLoaded = false;

    public static List<string> getUsedWords()
    {
        return usedWords;
    }

    public static int getFiveAvailable()
    {
        if (PlayerPrefs.HasKey("FiveAvailable"))
        {
            return PlayerPrefs.GetInt("FiveAvailable");
        }
        else
        {
            PlayerPrefs.SetInt("FiveAvailable", 686);
            return 686;
        }
    }

    public static void fiveUsed()
    {
        PlayerPrefs.SetInt("FiveAvailable", PlayerPrefs.GetInt("FiveAvailable") - 1);
    }

    public static int getEightAvailable()
    {
        return eightAvailable;
    }

    public static void eightUsed()
    {
        eightAvailable--;
    }

    public static int getTwelveAvailable()
    {
        return twelveAvailable;
    }

    public static void twelveUsed()
    {
        twelveAvailable--;
    }

    public static void setDemo()
    {
        PlayerPrefs.SetInt("FiveAvailable", 5);
        eightAvailable = 5;
        twelveAvailable = 5;
    }

    public static void reset()
    {
        usedWords.Clear();
    }

    /*
     * Checks if the word has been played before
     *      Checks if the Dictionary usedWords contains the key of the answer sorted alphabetically
     * If the word has been played before
     *      returns true
     * If the word hasn't been played before
     *      adds the word to the dictionary with the key as the answer sorted and the value as the answer
     *      returns false
     * Called in SelectWord
     */
    public static bool checkUsed(string answer)
    {
        if (!dataLoaded)
        {
            dataLoaded = true;
        }
        if(usedWords.Contains(answer))
        {
            return true;
        }
        else
        {
            usedWords.Add(answer);
            return false;
        }
    }

    public static void saveList()
    {
        string saved = "";
        foreach (string word in usedWords)
        {
            if(word != "")
            {
                saved += word + ",";
            }
        }
        PlayerPrefs.SetString("SavedWords", saved);
    }

    public static void loadList()
    {
        string[] wordList = PlayerPrefs.GetString("SavedWords").Split(',');
        foreach (string word in wordList)
        {
            usedWords.Add(word);
        }
    }
}
