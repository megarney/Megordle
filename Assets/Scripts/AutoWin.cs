using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoWin : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI autoWinText;

    void Start()
    {
        autoWinText.text = "the correct answer was: " + Game.GetAnswer();
    }

}
