using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float deathMenuAppearTime = 0f;

    public Transform DeathMenuCanvas;
    public IsDead isDead;


    void Update()
    {
        if (isDead.died == true)
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