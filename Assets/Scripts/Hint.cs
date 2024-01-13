using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{

    private static int hintIndex;

    public static int GetIndex()
    {
        return hintIndex;
    }

    public static string hint(string wordle)
    {
        string output = "";
        string answer = Game.GetAnswer();
        bool hasHint = false;
        int index = 0;
        foreach (char letter in wordle)
        {
            if(letter.Equals('_') && !hasHint)
            {
                char[] wordlearr = wordle.ToCharArray();
                wordlearr[index] = answer[index];
                output = new string(wordlearr);
                hasHint = true;
                hintIndex = index;
            }
            index++;
        }
        Debug.Log(output);
        return output;
    }
}
