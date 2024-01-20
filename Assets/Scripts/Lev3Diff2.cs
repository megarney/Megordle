using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Lev3Diff2 : MonoBehaviour
{
    static string scrambled;
    string filled; //shows '0's if there is no letter in that index in the player's guess and '1's if there is a letter (sh_w_ => 11010)
    string wordle;
    string guess;

    [SerializeField] private TextMeshProUGUI megashText;
    [SerializeField] private TextMeshProUGUI IncorrectText;

    [SerializeField] private TextMeshProUGUI PreviousGuessesText;

    //Controls the text that contains the player's guess
    [SerializeField] private TextMeshProUGUI FirstLetterGuess;
    [SerializeField] private TextMeshProUGUI SecondLetterGuess;
    [SerializeField] private TextMeshProUGUI ThirdLetterGuess;
    [SerializeField] private TextMeshProUGUI FourthLetterGuess;
    [SerializeField] private TextMeshProUGUI FifthLetterGuess;
    [SerializeField] private TextMeshProUGUI SixthLetterGuess;
    [SerializeField] private TextMeshProUGUI SeventhLetterGuess;
    [SerializeField] private TextMeshProUGUI EighthLetterGuess;
    [SerializeField] private TextMeshProUGUI NinthLetterGuess;
    [SerializeField] private TextMeshProUGUI TenthLetterGuess;
    [SerializeField] private TextMeshProUGUI EleventhLetterGuess;
    [SerializeField] private TextMeshProUGUI TwelfthLetterGuess;

    //Controls the text that is displayed on each of the buttons
    [SerializeField] private TextMeshProUGUI FirstLetterText;
    [SerializeField] private TextMeshProUGUI SecondLetterText;
    [SerializeField] private TextMeshProUGUI ThirdLetterText;
    [SerializeField] private TextMeshProUGUI FourthLetterText;
    [SerializeField] private TextMeshProUGUI FifthLetterText;
    [SerializeField] private TextMeshProUGUI SixthLetterText;
    [SerializeField] private TextMeshProUGUI SeventhLetterText;
    [SerializeField] private TextMeshProUGUI EighthLetterText;
    [SerializeField] private TextMeshProUGUI NinthLetterText;
    [SerializeField] private TextMeshProUGUI TenthLetterText;
    [SerializeField] private TextMeshProUGUI EleventhLetterText;
    [SerializeField] private TextMeshProUGUI TwelfthLetterText;
    [SerializeField] private TextMeshProUGUI ThirteenthLetterText;

    //Controls the buttons
    [SerializeField] private Button FirstLetterBtn;
    [SerializeField] private Button SecondLetterBtn;
    [SerializeField] private Button ThirdLetterBtn;
    [SerializeField] private Button FourthLetterBtn;
    [SerializeField] private Button FifthLetterBtn;
    [SerializeField] private Button SixthLetterBtn;
    [SerializeField] private Button SeventhLetterBtn;
    [SerializeField] private Button EighthLetterBtn;
    [SerializeField] private Button NinthLetterBtn;
    [SerializeField] private Button TenthLetterBtn;
    [SerializeField] private Button EleventhLetterBtn;
    [SerializeField] private Button TwelfthLetterBtn;
    [SerializeField] private Button ThirteenthLetterBtn;

    //Controls the user's attempts/hearts
    [SerializeField] private Image attemptOne;
    [SerializeField] private Image attemptTwo;
    [SerializeField] private Image attemptThree;
    [SerializeField] private Image attemptFour;
    [SerializeField] private Image attemptFive;
    [SerializeField] private Image attemptSix;
    [SerializeField] private Image attemptSeven;
    [SerializeField] private Image attemptEight;

    [SerializeField] private Button hintBtn;
    [SerializeField] private Button autoWinBtn;

    /*
     * Method for the help button
     */
    public void toHelp()
    {
        PlayerPrefs.SetString("LevelThreeAnswer", Game.GetAnswer());
        PlayerPrefs.SetString("LevelThreeWordle", wordle);
        PlayerPrefs.SetInt("LevelThreeAttempts", Attempt.GetAttempts());
        PlayerPrefs.SetString("LevelThreeScrambled", scrambled);
        PlayerPrefs.SetInt("LevelThreePoints", Points.getPoints());
        PlayerPrefs.SetString("LevelThreeGuesses", PreviousGuessesText.text);

        PlayerPrefs.SetInt("LevelThree", 1);

        Help.SetScene("Lev3Diff2");
        SceneManager.LoadSceneAsync("Help");
    }

    /*
     * Method for the main menu button
     */
    public void toMain()
    {
        PlayerPrefs.SetString("LevelThreeAnswer", Game.GetAnswer());
        PlayerPrefs.SetString("LevelThreeWordle", wordle);
        PlayerPrefs.SetInt("LevelThreeAttempts", Attempt.GetAttempts());
        PlayerPrefs.SetString("LevelThreeScrambled", scrambled);
        PlayerPrefs.SetInt("LevelThreePoints", Points.getPoints());
        PlayerPrefs.SetString("LevelThreeGuesses", PreviousGuessesText.text);

        PlayerPrefs.SetInt("LevelThree", 1);

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
        filled = "000000000000";
        guess = "____________";
        wordle = "____________";

        FirstLetterGuess.text = "";
        SecondLetterGuess.text = "";
        ThirdLetterGuess.text = "";
        FourthLetterGuess.text = "";
        FifthLetterGuess.text = "";
        SixthLetterGuess.text = "";
        SeventhLetterGuess.text = "";
        EighthLetterGuess.text = "";
        NinthLetterGuess.text = "";
        TenthLetterGuess.text = "";
        EleventhLetterGuess.text = "";
        TwelfthLetterGuess.text = "";

        FirstLetterBtn.onClick.AddListener(FirstLetterBtnOnclick);
        SecondLetterBtn.onClick.AddListener(SecondLetterBtnOnclick);
        ThirdLetterBtn.onClick.AddListener(ThirdLetterBtnOnclick);
        FourthLetterBtn.onClick.AddListener(FourthLetterBtnOnclick);
        FifthLetterBtn.onClick.AddListener(FifthLetterBtnOnclick);
        SixthLetterBtn.onClick.AddListener(SixthLetterBtnOnclick);
        SeventhLetterBtn.onClick.AddListener(SeventhLetterBtnOnclick);
        EighthLetterBtn.onClick.AddListener(EighthLetterBtnOnclick);
        NinthLetterBtn.onClick.AddListener(NinthLetterBtnOnclick);
        TenthLetterBtn.onClick.AddListener(TenthLetterBtnOnclick);
        EleventhLetterBtn.onClick.AddListener(EleventhLetterBtnOnclick);
        TwelfthLetterBtn.onClick.AddListener(TwelfthLetterBtnOnclick);
        ThirteenthLetterBtn.onClick.AddListener(ThirteenthLetterBtnOnclick);

        FirstLetterText.text = scrambled.Substring(0, 1);
        SecondLetterText.text = scrambled.Substring(1, 1);
        ThirdLetterText.text = scrambled.Substring(2, 1);
        FourthLetterText.text = scrambled.Substring(3, 1);
        FifthLetterText.text = scrambled.Substring(4, 1);
        SixthLetterText.text = scrambled.Substring(5, 1);
        SeventhLetterText.text = scrambled.Substring(6, 1);
        EighthLetterText.text = scrambled.Substring(7, 1);
        NinthLetterText.text = scrambled.Substring(8, 1);
        TenthLetterText.text = scrambled.Substring(9, 1);
        EleventhLetterText.text = scrambled.Substring(10, 1);
        TwelfthLetterText.text = scrambled.Substring(11, 1);
        ThirteenthLetterText.text = scrambled.Substring(12);

        if (PlayerPrefs.GetInt("LevelThree") == 1)
        {
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 7)
            {
                attemptOne.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 6)
            {
                attemptTwo.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 5)
            {
                attemptThree.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 4)
            {
                attemptFour.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 3)
            {
                attemptFive.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 2)
            {
                attemptSix.enabled = false;
            }
            if (PlayerPrefs.GetInt("LevelThreeAttempts") <= 1)
            {
                attemptSeven.enabled = false;
            }
            wordle = PlayerPrefs.GetString("LevelThreeWordle");
            contWordle();

            if (!PlayerPrefs.GetString("LevelThreeGuesses").Equals(""))
            {
                PreviousGuessesText.text = PlayerPrefs.GetString("LevelThreeGuesses");
            }
        }
        else
        {
            PlayerPrefs.SetString("LevelThreeGuesses", "");
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
        if (!filled.Equals("111111111111"))
        {
            addLetter(FirstLetterText.text);
            FirstLetterBtn.interactable = false;
        }
    }

    public void SecondLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(SecondLetterText.text);
            SecondLetterBtn.interactable = false;
        }
    }

    public void ThirdLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(ThirdLetterText.text);
            ThirdLetterBtn.interactable = false;
        }
    }

    public void FourthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(FourthLetterText.text);
            FourthLetterBtn.interactable = false;
        }
    }

    public void FifthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(FifthLetterText.text);
            FifthLetterBtn.interactable = false;
        }
    }

    public void SixthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(SixthLetterText.text);
            SixthLetterBtn.interactable = false;
        }
    }

    public void SeventhLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(SeventhLetterText.text);
            SeventhLetterBtn.interactable = false;
        }
    }

    public void EighthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(EighthLetterText.text);
            EighthLetterBtn.interactable = false;
        }
    }

    public void NinthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(NinthLetterText.text);
            NinthLetterBtn.interactable = false;
        }
    }

    public void TenthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(TenthLetterText.text);
            TenthLetterBtn.interactable = false;
        }
    }

    public void EleventhLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(EleventhLetterText.text);
            EleventhLetterBtn.interactable = false;
        }
    }

    public void TwelfthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(TwelfthLetterText.text);
            TwelfthLetterBtn.interactable = false;
        }
    }

    public void ThirteenthLetterBtnOnclick()
    {
        if (!filled.Equals("111111111111"))
        {
            addLetter(ThirteenthLetterText.text);
            ThirteenthLetterBtn.interactable = false;
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
                else if (ind == 5)
                {
                    SixthLetterGuess.text = letter;
                }
                else if (ind == 6)
                {
                    SeventhLetterGuess.text = letter;
                }
                else if (ind == 7)
                {
                    EighthLetterGuess.text = letter;
                }
                else if (ind == 8)
                {
                    NinthLetterGuess.text = letter;
                }
                else if (ind == 9)
                {
                    TenthLetterGuess.text = letter;
                }
                else if (ind == 10)
                {
                    EleventhLetterGuess.text = letter;
                }
                else if (ind == 11)
                {
                    TwelfthLetterGuess.text = letter;
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
        if (!filled.Equals("000000000000"))
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
        else if (index == 5)
        {
            EnableButton(SixthLetterGuess.text);
            SixthLetterGuess.text = "";
        }
        else if (index == 6)
        {
            EnableButton(SeventhLetterGuess.text);
            SeventhLetterGuess.text = "";
        }
        else if (index == 7)
        {
            EnableButton(EighthLetterGuess.text);
            EighthLetterGuess.text = "";
        }
        else if (index == 8)
        {
            EnableButton(NinthLetterGuess.text);
            NinthLetterGuess.text = "";
        }
        else if (index == 9)
        {
            EnableButton(TenthLetterGuess.text);
            TenthLetterGuess.text = "";
        }
        else if (index == 10)
        {
            EnableButton(EleventhLetterGuess.text);
            EleventhLetterGuess.text = "";
        }
        else if (index == 11)
        {
            EnableButton(TwelfthLetterGuess.text);
            TwelfthLetterGuess.text = "";
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
        if (guess.Equals(Game.GetAnswer()))
        {
            Streak.increaseStreak();
            SceneManager.LoadSceneAsync("Correct");
        }
        else
        {
            PreviousGuessesText.text += guess + "\n";
            failedAttempt();
            doWordle();
            IncorrectText.enabled = true;
            Invoke("DisableText", 3f);
        }
    }

    private void DisableText()
    {
        IncorrectText.enabled = false;
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
            SceneManager.LoadSceneAsync("Fail");
        }
        else if (attempts == 0)
        {
            SceneManager.LoadSceneAsync("Fail");
        }
        else
        {
            if (attempts == 7)
            {
                attemptOne.enabled = false;
            }
            else if (attempts == 6)
            {
                attemptTwo.enabled = false;
            }
            else if (attempts == 5)
            {
                attemptThree.enabled = false;
            }
            else if (attempts == 4)
            {
                attemptFour.enabled = false;
            }
            else if (attempts == 3)
            {
                attemptFive.enabled = false;
            }
            else if (attempts == 2)
            {
                attemptSix.enabled = false;
            }
            else if (attempts == 1)
            {
                attemptSeven.enabled = false;
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
                else if (ind == 5)
                {
                    EnableButton(SixthLetterGuess.text);
                    SixthLetterGuess.text = "";
                }
                else if (ind == 6)
                {
                    EnableButton(SeventhLetterGuess.text);
                    SeventhLetterGuess.text = "";
                }
                else if (ind == 7)
                {
                    EnableButton(EighthLetterGuess.text);
                    EighthLetterGuess.text = "";
                }
                else if (ind == 8)
                {
                    EnableButton(NinthLetterGuess.text);
                    NinthLetterGuess.text = "";
                }
                else if (ind == 9)
                {
                    EnableButton(TenthLetterGuess.text);
                    TenthLetterGuess.text = "";
                }
                else if (ind == 10)
                {
                    EnableButton(EleventhLetterGuess.text);
                    EleventhLetterGuess.text = "";
                }
                else if (ind == 11)
                {
                    EnableButton(TwelfthLetterGuess.text);
                    TwelfthLetterGuess.text = "";
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
        else if (letter.Equals(EighthLetterText.text) && EighthLetterBtn.interactable == false)
        {
            EighthLetterBtn.interactable = true;
        }
        else if (letter.Equals(NinthLetterText.text) && NinthLetterBtn.interactable == false)
        {
            NinthLetterBtn.interactable = true;
        }
        else if (letter.Equals(TenthLetterText.text) && TenthLetterBtn.interactable == false)
        {
            TenthLetterBtn.interactable = true;
        }
        else if (letter.Equals(EleventhLetterText.text) && EleventhLetterBtn.interactable == false)
        {
            EleventhLetterBtn.interactable = true;
        }
        else if (letter.Equals(TwelfthLetterText.text) && TwelfthLetterBtn.interactable == false)
        {
            TwelfthLetterBtn.interactable = true;
        }
        else if (letter.Equals(ThirteenthLetterText.text) && ThirteenthLetterBtn.interactable == false)
        {
            ThirteenthLetterBtn.interactable = true;
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
                else if (ind == 5)
                {
                    SixthLetterGuess.text = letter.ToString();
                }
                else if (ind == 6)
                {
                    SeventhLetterGuess.text = letter.ToString();
                }
                else if (ind == 7)
                {
                    EighthLetterGuess.text = letter.ToString();
                }
                else if (ind == 8)
                {
                    NinthLetterGuess.text = letter.ToString();
                }
                else if (ind == 9)
                {
                    TenthLetterGuess.text = letter.ToString();
                }
                else if (ind == 10)
                {
                    EleventhLetterGuess.text = letter.ToString();
                }
                else if (ind == 11)
                {
                    TwelfthLetterGuess.text = letter.ToString();
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
        else if (letter.Equals(EighthLetterText.text) && EighthLetterBtn.interactable == true)
        {
            EighthLetterBtn.interactable = false;
        }
        else if (letter.Equals(NinthLetterText.text) && NinthLetterBtn.interactable == true)
        {
            NinthLetterBtn.interactable = false;
        }
        else if (letter.Equals(TenthLetterText.text) && TenthLetterBtn.interactable == true)
        {
            TenthLetterBtn.interactable = false;
        }
        else if (letter.Equals(EleventhLetterText.text) && EleventhLetterBtn.interactable == true)
        {
            EleventhLetterBtn.interactable = false;
        }
        else if (letter.Equals(TwelfthLetterText.text) && TwelfthLetterBtn.interactable == true)
        {
            TwelfthLetterBtn.interactable = false;
        }
        else if (letter.Equals(ThirteenthLetterText.text) && ThirteenthLetterBtn.interactable == true)
        {
            ThirteenthLetterBtn.interactable = false;
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
            wordle = Hint.hint("________");
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
        else if (hintIndex == 5)
        {
            SixthLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 6)
        {
            SeventhLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 7)
        {
            EighthLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 8)
        {
            NinthLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 9)
        {
            TenthLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 10)
        {
            EleventhLetterGuess.text = letter.ToString();
        }
        else if (hintIndex == 11)
        {
            TwelfthLetterGuess.text = letter.ToString();
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
