using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Lev1Diff3 : MonoBehaviour
{
    static string scrambled;
    string filled; //shows '0's if there is no letter in that index in the player's guess and '1's if there is a letter (sh_w_ => 11010)
    string wordle;
    string guess;

    [SerializeField] private TextMeshProUGUI megashText;
    [SerializeField] private TextMeshProUGUI IncorrectText;
    [SerializeField] private TextMeshProUGUI UnfilledSlotsText;

    [SerializeField] private TextMeshProUGUI PreviousGuessesText;

    //Controls the text that contains the player's guess
    [SerializeField] private TextMeshProUGUI FirstLetterGuess;
    [SerializeField] private TextMeshProUGUI SecondLetterGuess;
    [SerializeField] private TextMeshProUGUI ThirdLetterGuess;
    [SerializeField] private TextMeshProUGUI FourthLetterGuess;
    [SerializeField] private TextMeshProUGUI FifthLetterGuess;

    //Controls the text that is displayed on each of the buttons
    [SerializeField] private TextMeshProUGUI FirstLetterText;
    [SerializeField] private TextMeshProUGUI SecondLetterText;
    [SerializeField] private TextMeshProUGUI ThirdLetterText;
    [SerializeField] private TextMeshProUGUI FourthLetterText;
    [SerializeField] private TextMeshProUGUI FifthLetterText;
    [SerializeField] private TextMeshProUGUI SixthLetterText;
    [SerializeField] private TextMeshProUGUI SeventhLetterText;

    //Controls the buttons
    [SerializeField] private Button FirstLetterBtn;
    [SerializeField] private Button SecondLetterBtn;
    [SerializeField] private Button ThirdLetterBtn;
    [SerializeField] private Button FourthLetterBtn;
    [SerializeField] private Button FifthLetterBtn;
    [SerializeField] private Button SixthLetterBtn;
    [SerializeField] private Button SeventhLetterBtn;

    //Controls the user's attempts/hearts
    [SerializeField] private Image attemptOne;
    [SerializeField] private Image attemptTwo;
    [SerializeField] private Image attemptThree;
    [SerializeField] private Image attemptFour;

    [SerializeField] private Button hintBtn;
    [SerializeField] private Button autoWinBtn;

    [SerializeField] private Image notRightWord;

    /*
     * Method for the help button
     */
    public void toHelp()
    {
        PlayerPrefs.SetString("LevelOneAnswer", Game.GetAnswer());
        PlayerPrefs.SetString("LevelOneWordle", wordle);
        PlayerPrefs.SetInt("LevelOneDiff", 3);
        PlayerPrefs.SetInt("LevelOneAttempts", Attempt.GetAttempts());
        PlayerPrefs.SetString("LevelOneScrambled", scrambled);
        PlayerPrefs.SetInt("LevelOnePoints", Points.getPoints());
        PlayerPrefs.SetString("LevelOneGuesses", PreviousGuessesText.text);

        PlayerPrefs.SetInt("LevelOne", 1);

        Help.SetScene("Lev1Diff3");
        SceneManager.LoadSceneAsync("Help");
    }

    /*
     * Method for the main menu button
     */
    public void toMain()
    {
        PlayerPrefs.SetString("LevelOneAnswer", Game.GetAnswer());
        PlayerPrefs.SetString("LevelOneWordle", wordle);
        PlayerPrefs.SetInt("LevelOneDiff", 3);
        PlayerPrefs.SetInt("LevelOneAttempts", Attempt.GetAttempts());
        PlayerPrefs.SetString("LevelOneScrambled", scrambled);
        PlayerPrefs.SetInt("LevelOnePoints", Points.getPoints());
        PlayerPrefs.SetString("LevelOneGuesses", PreviousGuessesText.text);

        PlayerPrefs.SetInt("LevelOne", 1);

        SceneManager.LoadSceneAsync("Main Menu");
    }

    /*
     * Sets the Megash total
     * Sets the answer to a textbox that is off screen TODO: DELETE
     * Sets the Megordle from Game
     * Disables the text that displays when the user guess' wrong
     * Sets the filled to 00000
     * Sets the guess to _____
     * Sets the guess texts to empty
     * Adds listeners to all the buttons
     * Sets the text for the buttons
     */
    void Start()
    {
        UsedWords.saveList();

        megashText.text = Megash.getTotalCash().ToString();
        scrambled = Game.GetScrambled();
        IncorrectText.enabled = false;
        UnfilledSlotsText.enabled = false;
        notRightWord.enabled = false;
        filled = "00000";
        guess = "_____";
        wordle = "_____";

        FirstLetterGuess.text = "";
        SecondLetterGuess.text = "";
        ThirdLetterGuess.text = "";
        FourthLetterGuess.text = "";
        FifthLetterGuess.text = "";

        FirstLetterBtn.onClick.AddListener(FirstLetterBtnOnclick);
        SecondLetterBtn.onClick.AddListener(SecondLetterBtnOnclick);
        ThirdLetterBtn.onClick.AddListener(ThirdLetterBtnOnclick);
        FourthLetterBtn.onClick.AddListener(FourthLetterBtnOnclick);
        FifthLetterBtn.onClick.AddListener(FifthLetterBtnOnclick);
        SixthLetterBtn.onClick.AddListener(SixthLetterBtnOnclick);
        SeventhLetterBtn.onClick.AddListener(SeventhLetterBtnOnclick);

        FirstLetterText.text = scrambled.Substring(0, 1);
        SecondLetterText.text = scrambled.Substring(1, 1);
        ThirdLetterText.text = scrambled.Substring(2, 1);
        FourthLetterText.text = scrambled.Substring(3, 1);
        FifthLetterText.text = scrambled.Substring(4, 1);
        SixthLetterText.text = scrambled.Substring(5, 1);
        SeventhLetterText.text = scrambled.Substring(6);


        if (PlayerPrefs.GetInt("LevelOne") == 1)
        {
            if (PlayerPrefs.GetInt("LevelOneAttempts") <= 3)
            {
                attemptOne.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelOneAttempts") <= 2)
            {
                attemptTwo.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelOneAttempts") <= 1)
            {
                attemptThree.enabled = false;
            }
            wordle = PlayerPrefs.GetString("LevelOneWordle");
            contWordle();

            if (!PlayerPrefs.GetString("LevelOneGuesses").Equals(""))
            {
                PreviousGuessesText.text = PlayerPrefs.GetString("LevelOneGuesses");
            }
        }
        else
        {
            PlayerPrefs.SetString("LevelOneGuesses", "");
        }

        if (Megash.getTotalCash() < 50)
        {
            hintBtn.enabled = false;
        }
        else
        {
            hintBtn.enabled = true;
            hintBtn.onClick.AddListener(hint);
        }

        if (Megash.getTotalCash() < 500)
        {
            autoWinBtn.enabled = false;
        }
        else
        {
            autoWinBtn.enabled = true;
            autoWinBtn.onClick.AddListener(autoWin);
        }
    }

    /*
     * Methods for each of the Megordle buttons
     * When a button is clicked,
     * if not all of the guess texts are filled
     * Calls addLetter to add the letter to the guess
     * Disables that button
     */
    public void FirstLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(FirstLetterText.text);
            FirstLetterBtn.interactable = false;
        }
    }

    public void SecondLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(SecondLetterText.text);
            SecondLetterBtn.interactable = false;
        }
    }

    public void ThirdLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(ThirdLetterText.text);
            ThirdLetterBtn.interactable = false;
        }
    }

    public void FourthLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(FourthLetterText.text);
            FourthLetterBtn.interactable = false;
        }
    }

    public void FifthLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(FifthLetterText.text);
            FifthLetterBtn.interactable = false;
        }
    }

    public void SixthLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(SixthLetterText.text);
            SixthLetterBtn.interactable = false;
        }
    }

    public void SeventhLetterBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            addLetter(SeventhLetterText.text);
            SeventhLetterBtn.interactable = false;
        }
    }

    /*
     * Given the letter that is being added from the on click methods,
     * Will add the letter to the next available unfilled guess text
     */
    private void addLetter(string letter)
    {
        int ind = 0;
        foreach (char spot in filled)
        {
            if (spot.Equals('0'))
            {
                if (ind == 0)
                {
                    FirstLetterGuess.text = letter;
                }
                else if (ind == 1)
                {
                    SecondLetterGuess.text = letter;
                }
                else if (ind == 2)
                {
                    ThirdLetterGuess.text = letter;
                }
                else if (ind == 3)
                {
                    FourthLetterGuess.text = letter;
                }
                else if (ind == 4)
                {
                    FifthLetterGuess.text = letter;
                }
                char[] filledarr = filled.ToCharArray();
                filledarr[ind] = '1';
                filled = new string(filledarr);
                char[] guessarr = guess.ToCharArray();
                guessarr[ind] = char.Parse(letter);
                guess = new string(guessarr);
                break;
            }
            ind++;
        }
    }

    /*
     * Method for the delete button
     * If the guess is not empty,
     * Gets the index of the last letter that the player guessed that was not approved in the wordle
     * Resets filled to show a '0' in place of the deleted letter
     * Calls removeLetter(index) to remove
     */
    public void DeleteBtnOnclick()
    {
        if (!filled.Equals("00000"))
        {
            int ind = 0;
            int indone = -1;
            foreach (char spot in filled)
            {
                if (spot.Equals('1') && wordle[ind].Equals('_'))
                {
                    indone = ind;
                }
                ind++;
            }
            if (indone > -1)
            {
                char[] filledarr = filled.ToCharArray();
                filledarr[indone] = '0';
                filled = new string(filledarr);
                removeLetter(indone);
            }
        }
    }

    /*
     * Empties the guess text of the letter at the specified index
     * Calls EnableButton() to reenable the button for the letter that was deleted
     */
    private void removeLetter(int index)
    {
        if (index == 0)
        {
            EnableButton(FirstLetterGuess.text);
            FirstLetterGuess.text = "";
        }
        else if (index == 1)
        {
            EnableButton(SecondLetterGuess.text);
            SecondLetterGuess.text = "";
        }
        else if (index == 2)
        {
            EnableButton(ThirdLetterGuess.text);
            ThirdLetterGuess.text = "";
        }
        else if (index == 3)
        {
            EnableButton(FourthLetterGuess.text);
            FourthLetterGuess.text = "";
        }
        else if (index == 4)
        {
            EnableButton(FifthLetterGuess.text);
            FifthLetterGuess.text = "";
        }
    }

    /*
     * Method for the guess button
     * If the guess is correct, 
     *      calls Streak to increase the player's streak
     *      directs user to the Correct scene
     * If the guess in wrong,
     *      calls failedAttempt()
     *      calls doWordle()
     *      displays 'Incorrect. Try again!' to the user for 3 seconds
     */
    public void GuessBtnOnclick()
    {
        if (!filled.Equals("11111"))
        {
            if (IncorrectText.enabled)
            {
                IncorrectText.enabled = false;
            }
            if (notRightWord.enabled)
            {
                notRightWord.enabled = false;
                Invoke("DisableText", 3f);
            }
            UnfilledSlotsText.enabled = true;
            Invoke("DisableText", 3f);
        }
        else if (guess.Equals(Game.GetAnswer()))
        {
            Streak.increaseStreak();
            SceneManager.LoadSceneAsync("Correct");
        }
        else if (CheckIfWord.checkIfWord(guess))
        {
            if (UnfilledSlotsText.enabled)
            {
                UnfilledSlotsText.enabled = false;
                Invoke("DisableText", 3f);
            }
            if (IncorrectText.enabled)
            {
                IncorrectText.enabled = false;
            }
            notRightWord.enabled = true;
            Invoke("DisableText", 3f);
            doWordle();
        }
        else
        {
            PreviousGuessesText.text += guess + "\n";
            failedAttempt();
            doWordle();
            if (UnfilledSlotsText.enabled)
            {
                UnfilledSlotsText.enabled = false;
                Invoke("DisableText", 3f);
            }
            if (notRightWord.enabled)
            {
                notRightWord.enabled = false;
                Invoke("DisableText", 3f);
            }
            IncorrectText.enabled = true;
            Invoke("DisableText", 3f);
        }
    }

    private void DisableText()
    {
        IncorrectText.enabled = false;
        UnfilledSlotsText.enabled = false;
        notRightWord.enabled = false;
    }

    /*
     * Calls failedAttempt() in Points to lose points
     * Calls failedAttempt() in Attempt to lost an attempt and set attempts to the amount of attempts left
     * If the player is out of attempts and has 50 or more Megash
     *      directs the player to the Buy Attempt scene TODO: Reset from fail to Buy Attempt once Buy Attempt is working
     * If the player is out of attempts and does not have 50 or more Megash
     *      directs the player to the Fail scene
     * Else
     *      Disables the hearts to show the user how many attempts the user has left
     */
    public void failedAttempt()
    {
        Points.failedAttempt();
        int attempts = Attempt.failedAttempt();
        if (attempts == 0 && PlayerPrefs.GetInt("Megash") >= 50)
        {
            doWordle();

            PlayerPrefs.SetString("LevelOneWordle", wordle);
            PlayerPrefs.SetInt("LevelOneDiff", 1);
            PlayerPrefs.SetInt("LevelOneAttempts", Attempt.GetAttempts());
            PlayerPrefs.SetString("LevelOneScrambled", scrambled);
            PlayerPrefs.SetInt("LevelOnePoints", Points.getPoints());
            PlayerPrefs.SetString("LevelOneGuesses", PreviousGuessesText.text);
            PlayerPrefs.SetInt("LevelOne", 1);

            BuyAttempt.SetScene("Lev1Diff3");
            SceneManager.LoadSceneAsync("Buy Attempt");
        }
        else if (attempts == 0)
        {
            SceneManager.LoadSceneAsync("Fail");
        }
        else
        {
            if (attempts == 3)
            {
                attemptOne.enabled = false;
            }
            else if (attempts == 2)
            {
                attemptTwo.enabled = false;
            }
            else if (attempts == 1)
            {
                attemptThree.enabled = false;
            }
        }
    }

    /*
     * Gets the wordle from Game
     * For each of the letters that were correct in the player's guess
     *      Leaves the letter displayed in the correct spot to the user
     * For each of the letters that were wrong in the player's guess
     *      Calls EnableButton() to reenable the button of the letters
     *      Empties the letter spot in the guess
     *      Resets the guess to show a '_' for any wrong letters
     *      Resets the filled to show a '0' for any wrong letters
     */
    public void doWordle()
    {
        wordle = Game.checkCorrect(guess);
        int ind = 0;
        filled = "";
        foreach (char letter in wordle)
        {
            if (letter.Equals('_'))
            {
                if (ind == 0)
                {
                    EnableButton(FirstLetterGuess.text);
                    FirstLetterGuess.text = "";
                }
                else if (ind == 1)
                {
                    EnableButton(SecondLetterGuess.text);
                    SecondLetterGuess.text = "";
                }
                else if (ind == 2)
                {
                    EnableButton(ThirdLetterGuess.text);
                    ThirdLetterGuess.text = "";
                }
                else if (ind == 3)
                {
                    EnableButton(FourthLetterGuess.text);
                    FourthLetterGuess.text = "";
                }
                else if (ind == 4)
                {
                    EnableButton(FifthLetterGuess.text);
                    FifthLetterGuess.text = "";
                }
                char[] guessarr = guess.ToCharArray();
                guessarr[ind] = '_';
                guess = new string(guessarr);
                filled += "0";
            }
            else
            {
                filled += "1";
            }
            ind++;
        }
    }

    /*
     * Reenables the button that corresponds to the specified letter
     */
    public void EnableButton(string letter)
    {
        if (letter.Equals(FirstLetterText.text) && FirstLetterBtn.interactable == false)
        {
            FirstLetterBtn.interactable = true;
        }
        else if (letter.Equals(SecondLetterText.text) && SecondLetterBtn.interactable == false)
        {
            SecondLetterBtn.interactable = true;
        }
        else if (letter.Equals(ThirdLetterText.text) && ThirdLetterBtn.interactable == false)
        {
            ThirdLetterBtn.interactable = true;
        }
        else if (letter.Equals(FourthLetterText.text) && FourthLetterBtn.interactable == false)
        {
            FourthLetterBtn.interactable = true;
        }
        else if (letter.Equals(FifthLetterText.text) && FifthLetterBtn.interactable == false)
        {
            FifthLetterBtn.interactable = true;
        }
        else if (letter.Equals(SixthLetterText.text) && SixthLetterBtn.interactable == false)
        {
            SixthLetterBtn.interactable = true;
        }
        else if (letter.Equals(SeventhLetterText.text) && SeventhLetterBtn.interactable == false)
        {
            SeventhLetterBtn.interactable = true;
        }
    }

    public void contWordle()
    {
        string answer = Game.GetAnswer();
        int ind = 0;
        filled = "";
        foreach (char letter in wordle)
        {
            if (!letter.Equals('_'))
            {
                DisableButton(letter.ToString());
                if (ind == 0)
                {
                    FirstLetterGuess.text = letter.ToString();
                }
                else if (ind == 1)
                {
                    SecondLetterGuess.text = letter.ToString();
                }
                else if (ind == 2)
                {
                    ThirdLetterGuess.text = letter.ToString();
                }
                else if (ind == 3)
                {
                    FourthLetterGuess.text = letter.ToString();
                }
                else if (ind == 4)
                {
                    FifthLetterGuess.text = letter.ToString();
                }
                char[] guessarr = guess.ToCharArray();
                guessarr[ind] = letter;
                guess = new string(guessarr);
                filled += "1";
            }
            else
            {
                filled += "0";
            }
            ind++;
        }
    }

    public void DisableButton(string letter)
    {
        if (letter.Equals(FirstLetterText.text) && FirstLetterBtn.interactable == true)
        {
            FirstLetterBtn.interactable = false;
        }
        else if (letter.Equals(SecondLetterText.text) && SecondLetterBtn.interactable == true)
        {
            SecondLetterBtn.interactable = false;
        }
        else if (letter.Equals(ThirdLetterText.text) && ThirdLetterBtn.interactable == true)
        {
            ThirdLetterBtn.interactable = false;
        }
        else if (letter.Equals(FourthLetterText.text) && FourthLetterBtn.interactable == true)
        {
            FourthLetterBtn.interactable = false;
        }
        else if (letter.Equals(FifthLetterText.text) && FifthLetterBtn.interactable == true)
        {
            FifthLetterBtn.interactable = false;
        }
        else if (letter.Equals(SixthLetterText.text) && SixthLetterBtn.interactable == true)
        {
            SixthLetterBtn.interactable = false;
        }
        else if (letter.Equals(SeventhLetterText.text) && SeventhLetterBtn.interactable == true)
        {
            SeventhLetterBtn.interactable = false;
        }
    }

    public void hint()
    {
        Megash.spend(50);
        megashText.text = Megash.getTotalCash().ToString();

        if (Megash.getTotalCash() < 50)
        {
            hintBtn.enabled = false;
        }

        if (wordle == null)
        {
            wordle = Hint.hint("_____");
        }
        else
        {
            wordle = Hint.hint(wordle);
        }

        int hintIndex = Hint.GetIndex();

        DisableButton(wordle[hintIndex].ToString());

        string letter = wordle[hintIndex].ToString();
        if (hintIndex == 0)
        {
            FirstLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 1)
        {
            SecondLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 2)
        {
            ThirdLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 3)
        {
            FourthLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 4)
        {
            FifthLetterGuess.text = letter.ToString();
        }

        char[] filledarr = filled.ToCharArray();
        filledarr[hintIndex] = '1';
        filled = new string(filledarr);

        char[] guessarr = guess.ToCharArray();
        guessarr[hintIndex] = letter[0];
        guess = new string(guessarr);
    }

    public void autoWin()
    {
        Megash.spend(500);
        SceneManager.LoadSceneAsync("AutoWin");
    }
}
