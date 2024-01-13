using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * Game
 * 1/2/2024
 * Keeps track of the game's level, difficulty, answer, answer with extra letters, Megordle, and wordle
 * Scrambles the answer with extra letters
 * Creates the wordle based on the player's guess
 */

public class Game : MonoBehaviour
{

    static string answer;
    static string addedAnswer;
    static string scrambled; //scrambled refers to the Megordle
    static int level;
    static int difficulty;
    static string wordle;
    

    public static void SetLevel(int lev)
    {
        level = lev;
    }

    public static int GetLevel()
    {
        return level;
    }

    public static void SetDifficulty(int diff)
    {
        difficulty = diff;
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static void SetAnswer(string ans)
    {
        answer = ans;
    }

    public static string GetAnswer()
    {
        return answer;
    }

    public static void SetAddedAnswer(string added)
    {
        addedAnswer = added;
    }

    public static string GetAddedAnswer()
    {
        return addedAnswer;
    }

    public static void SetScrambled(string scram)
    {
        scrambled = scram;
    }

    public static string GetScrambled()
    {
        return scrambled;
    }

    /*
     * Sets the wordle based on the level (ie the answer's length)
     */
    public static void SetWordle()
    {
        if(level == 1)
        {
            wordle = "_____";
        }
        else if(level == 2)
        {
            wordle = "________";
        }
        else if (level == 3)
        {
            wordle = "____________";
        }
    }

    public static void SetWordle(string word)
    {
        wordle = word;
    }

    /*
     * Scrambles the answer using an ArrayList
     * Stores the scrambled answer in scrambled
     * Will restart if the scrambled word is the same as the answer
     */
    public static void Scramble()
    {
        scrambled = "";
        var scrambler = new ArrayList();
        foreach(char letter in addedAnswer)
        {
            scrambler.Add(letter);
        }
        var rand = new System.Random();
        int index;
        for(int i = 0; i < addedAnswer.Length; i++)
        {
            index = rand.Next(0, scrambler.Count);
            scrambled += scrambler[index];
            scrambler.RemoveAt(index);
        }
        if(scrambled.Equals(answer))
        {
            Scramble();
        }
    }

    public static string getWordle()
    {
        return wordle;
    }

    /*
     * Creates the wordle given the player's guess and the answer
     * Any letters that are incorrect are shown by a '_'
     */
    public static string checkCorrect(string response)
    {
        int index = 0;
        char res;
        char ans;
        string newWordle = "";
        foreach(char letter in wordle)
        {
            if (letter.Equals('_'))
            {
                res = response[index];
                ans = answer[index];
                if(res.Equals(ans))
                {
                    newWordle += res;
                }
                else
                {
                    newWordle += letter;
                }
            }
            else
            {
                newWordle += letter;
            }
            index++;
        }
        wordle = newWordle;
        return wordle;
    }

}
