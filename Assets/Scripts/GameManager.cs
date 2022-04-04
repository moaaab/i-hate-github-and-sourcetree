using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float deathMenuAppearTime = 0f;

    public Transform DeathMenuCanvas;
    public Lives lives;

    void Update()
    {
        if (lives.nrOfLives == 0)
        {
            StartCoroutine(DeathMenu());
        }
    }

    IEnumerator DeathMenu()
    {
        yield return new WaitForSeconds(deathMenuAppearTime);
        DeathMenuCanvas.gameObject.SetActive(true);
    }
}