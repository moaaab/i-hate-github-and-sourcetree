using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsLeft : MonoBehaviour
{
    public Lives lives;
    public TextMeshProUGUI credits;

    private void Update()
    {
        credits.text = lives.nrOfLives.ToString();
    }
}
