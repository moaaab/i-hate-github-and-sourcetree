using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float deathMenuAppearTime = 0f;

    public Transform player;
    public Transform DeathMenuCanvas;
    public Lives lives;
    public IsDead died;
    public CheckPointCounter checkpoint;

    Vector3 checkpoint0 = new Vector3(0, 1, 0);

    Vector3 checkpoint1 = new Vector3(0, 1, 10);

    Vector3 checkpoint2 = new Vector3(0, 1, 20);

    private void Update()
    {
        if (lives.nrOfLives < 1)
        {
            StartCoroutine(DeathMenu());
        }

        else if (died.died)
        {
            if (checkpoint.checkPoint == 0)
            {
                player.transform.position = checkpoint0;
                died.died = false;
            }

            if (checkpoint.checkPoint == 1)
            {
                player.transform.position = checkpoint1;
                died.died = false;
            }

            if (checkpoint.checkPoint == 2)
            {
                player.transform.position = checkpoint2;
                died.died = false;
            }
        }
    }

    IEnumerator DeathMenu()
    {
        yield return new WaitForSeconds(deathMenuAppearTime);
        DeathMenuCanvas.gameObject.SetActive(true);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
    }
}