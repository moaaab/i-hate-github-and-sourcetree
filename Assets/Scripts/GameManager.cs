using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float deathMenuAppearTime = 0f;

    public player PlayerScript;

    //public Transform player;
    public Transform DeathMenuCanvas;
    public Transform player;
    public Lives lives;
    public IsDead died;
    public Transform theCamera;
    public backgroundrotate background;
    public AudioSource audioOne;
    public AudioSource audioTwo;
    public AudioSource audioThree;
    public Transform LoseCreditCanvas;
    public bool lostLife = true;
    public int countDownNumber = 3;
    public TextMeshProUGUI countDownText;

    Vector3 startPos = new Vector3(0.5f, 2.41f, -1.05f);
    Vector3 cameraStartPos = new Vector3(9.89f, 0.85f, 2.9f);

    Vector3 playerVelocity = new Vector3(0, 0, 0);

    //public Transform theCamera;
    //public CheckPointCounter checkpoint;

    /*Vector3 checkpoint0 = new Vector3(0, 0, 0);
    Vector3 cameraCheckpoint0 = new Vector3(9.89f, 0, 0);

    Vector3 checkpoint1 = new Vector3(0, 3, 96.12f);
    Vector3 cameraCheckpoint1 = new Vector3(9.89f, 0, 96.12f);

    Vector3 checkpoint2 = new Vector3(0, 1, 20);*/

    private void Start()
    {
        Time.timeScale = 0;
        countDownText.text = countDownNumber.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && !died.died)
        {
            Time.timeScale = 1;
        }

        if ((died.died && lives.nrOfLives > 0) && lostLife)
        {
            player.gameObject.SetActive(false);
            LoseCreditCanvas.gameObject.SetActive(true);
            StartCoroutine(CountDown(countDownNumber));
            StartCoroutine(LoseCredit());
            lostLife = false;
        }

        else if (lives.nrOfLives < 1)
        {
            StartCoroutine(DeathMenu());
            /* if (checkpoint.checkPoint == 0)
             {
                 player.transform.position = checkpoint0;
                 theCamera.transform.position = cameraCheckpoint0;
                 died.died = false;
             }

             if (checkpoint.checkPoint == 1)
             {
                 player.transform.position = checkpoint1;
                 theCamera.transform.position = cameraCheckpoint1;
                 died.died = false;
             }

             if (checkpoint.checkPoint == 2)
             {
                 Time.timeScale = 0;
                 player.transform.position = checkpoint2;
                 StartCoroutine(Pause());
                 died.died = false;
             }*/
            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator DeathMenu()
    {
        yield return new WaitForSeconds(deathMenuAppearTime);
        DeathMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        died.died = false;
    }

    IEnumerator LoseCredit()
    {
        yield return new WaitForSeconds(2);
        LoseCreditCanvas.gameObject.SetActive(false);
        Reset();
        player.gameObject.SetActive(true);
    }


    public void Reset()
    {
        player.transform.position = startPos;
        theCamera.transform.position = cameraStartPos;
        DeathMenuCanvas.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().velocity = playerVelocity;
        background.transform.position = new Vector3(-171.1f, -8.9f, 2.5f);
        if (lives.nrOfLives == 2)
        {
            audioTwo.Play();
        }
        if (lives.nrOfLives == 1)
        {
            audioThree.Play();
        }
        died.died = false;
        lostLife = true;
        PlayerScript.playerGravityState = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator CountDown(int i)
    {
        yield return new WaitForSeconds(0.5f);
        countDownText.text = i.ToString();
        i--;
        if (i >= 0)
        {
            StartCoroutine(CountDown(i));
        } else
        {
            i = 3;
            countDownText.text = i.ToString();
        }
    }
}