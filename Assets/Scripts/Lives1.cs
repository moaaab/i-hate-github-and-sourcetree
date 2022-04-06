using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI livesLeft;
    public AudioSource audioOne;
    public AudioSource audioTwo;
    public AudioSource audioThree;


    public int nrOfLives = 4;

    public void LoseLife()
    {
        nrOfLives--;
        livesLeft.text = nrOfLives.ToString();
        audioOne.Stop();
        audioTwo.Stop();
        audioThree.Stop();
    }
}
