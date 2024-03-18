using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfWord : MonoBehaviour
{
    [SerializeField] private TextAsset fiveLetterWords;
    [SerializeField] private TextAsset eightLetterWords;
    [SerializeField] private TextAsset twelveLetterWords;

    public static List<string> fiveLetterList = new List<string>();
    public static List<string> eightLetterList = new List<string>();
    public static List<string> twelveLetterList = new List<string>();

    void Awake()
    {
        if(fiveLetterList.Count == 0)
        {
            string[] fiveWordList = (fiveLetterWords.text).Split(',');
            foreach (string word in fiveWordList)
            {
                fiveLetterList.Add(word.ToLower());
            }
        }
    }

    public static bool checkIfWord(string word)
    {
        if(word.Length == 5)
        {
            if (fiveLetterList.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
