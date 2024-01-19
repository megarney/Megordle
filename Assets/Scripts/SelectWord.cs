using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/*
 * SelectWord
 * Selects the answer from the database
 * Adds extra letters based on difficulty
 */

public class SelectWord : MonoBehaviour
{
    /*
     * Selects the answer from the database
     * Calls UsedWords to check that the word hasn't been used before
     * Calls UsedWords to subtract from the number of words left
     */
    public static void SelectAnswer(int level)
    {
        string answer = "";
        
        var rand = new System.Random();
        int n = 0;
        if(level == 1)
        {
            n = rand.Next(0, 686);
        }
        else if(level == 2)
        {
            n = rand.Next(0, 5);
        }
        else if (level == 3)
        {
            n= rand.Next(0, 5);
        }

        string filename = "Assets/Database/demoFiveLetters.txt";
        if(level == 1)
        {
            filename = "Assets/Database/fiveLetterWords.txt";
        }
        if(level == 2)
        {
            filename = "Assets/Database/demoEightLetters.txt";
        }
        if (level == 3)
        {
            filename = "Assets/Database/demoTwelveLetters.txt";
        }

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                int index = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if(n == index)
                    {
                        answer = line;
                    }
                    index++;
                }
            }
        }
        catch(Exception exp)
        {
            Debug.Log("SelectWord error");
            Debug.Log(exp.Message);
        }
        if(UsedWords.checkUsed(answer) == true)
        {
            SelectAnswer(level);
        }
        else
        {
            if (level == 1)
            {
                UsedWords.fiveUsed();
            }
            if (level == 2)
            {
                UsedWords.eightUsed();
            }
            if (level == 3)
            {
                UsedWords.twelveUsed();
            }
            Game.SetAnswer(answer);
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

        for(int i = 1; i <= numAdded; i++)
        {
            num = rand.Next(0, 26);
            c = (char)('a' + num);
            if(c == 'r' || c == 'd' || c == 'y' || c == 's')
            {
                extraLetters(difficulty);
            }
            extra += c;
        }
        addedAnswer += extra.ToLower();
        Game.SetAddedAnswer(addedAnswer);
    }
}
