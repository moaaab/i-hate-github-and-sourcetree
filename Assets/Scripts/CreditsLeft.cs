using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsLeft : MonoBehaviour
{
    public Lives lives;
    public TextMeshProUGUI credits;
    public TextMeshProUGUI scoreText;
    public Score score;

    private void Update()
    {
        credits.text = lives.nrOfLives.ToString();
        scoreText.text = score.meterScore.ToString(); 
    }
}
