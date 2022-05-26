using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float deathMenuAppearTime = 0f;

    public player PlayerScript;
    public Transform player;
    public ParticleSystem deathEffect;
    //public Transform player;
    public Transform DeathMenuCanvas;

    public Transform sun;
    public Lives lives;
    public IsDead died;
    public Transform theCamera;
    public backgroundrotate background;
    public AudioSource audioOne;
    public AudioSource audioTwo;
    public AudioSource audioThree;
    public Transform LoseCreditCanvas;
    public Transform spaceCanvas;
    public bool lostLife = true;
    public int countDownNumber = 3;
    public TextMeshProUGUI countDownText;
    public bool musicPlayed = true;

    public CheckPointCounter checkpoint;

    Vector3 checkpoint1 = new Vector3(0.5f, 2.2f, 253.44f);
    Vector3 cameraCheckpoint1 = new Vector3(9.89f, 0.85f, 257.1f);

    Vector3 checkpoint2 = new Vector3(0.5f, -0.05f, 461.2f);
    Vector3 cameraCheckPoint2 = new Vector3(9.89f, 0.85f, 464.86f);

    Vector3 checkpoint3 = new Vector3(0.5f, -0.05f, 747.4399f);
    Vector3 cameraCheckPoint3 = new Vector3(9.89f, 0.85f, 751.0999f);

    Vector3 checkpoint4 = new Vector3(0.5f, -0.34f, 985.89f);
    Vector3 cameraCheckPoint4 = new Vector3(9.89f, 0.85f, 989.55f);

    Vector3 startPos = new Vector3(0.5f, 2.4f, -18.46f);
    Vector3 cameraStartPos = new Vector3(9.89f, 0.85f, -14.8f);

    Vector3 playerVelocity = new Vector3(0, 0, 0);

    //public Transform theCamera;
    //public CheckPointCounter checkpoint;

    /*Vector3 checkpoint0 = new Vector3(0, 0, 0);
    Vector3 cameraCheckpoint0 = new Vector3(9.89f, 0, 0);

    Vector3 checkpoint1 = new Vector3(0, 3, 96.12f);
    Vector3 cameraCheckpoint1 = new Vector3(9.89f, 0, 96.12f);

    Vector3 checkpoint2 = new Vector3(0, 1, 20);*/

    private void Awake()
    {
        player.transform.position = startPos;
    }

    private void Start()
    {
        Time.timeScale = 0;
        countDownText.text = countDownNumber.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && !died.died)
        {
            spaceCanvas.gameObject.SetActive(false);

            if (musicPlayed)
            {
                if (lives.nrOfLives == 3)
                {
                    audioOne.Play();
                }
                if (lives.nrOfLives == 2)
                {
                    audioTwo.Play();
                }
                if (lives.nrOfLives == 1)
                {
                    audioThree.Play();
                }
            }
            musicPlayed = false;
            Time.timeScale = 1;
        }

        if ((died.died && lives.nrOfLives > 0) && lostLife)
        {
            Instantiate(deathEffect, player.position, Quaternion.Euler(0, 90, 45));
            player.gameObject.SetActive(false);
            LoseCreditCanvas.gameObject.SetActive(true);
            StartCoroutine(CountDown(countDownNumber, 0.3f));
            StartCoroutine(LoseCredit());
            lostLife = false;
        }

        else if (lives.nrOfLives < 1)
        {

            if (died.died) StartCoroutine(DeathMenu());

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
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator DeathMenu()
    {
        
        yield return new WaitForSeconds(deathMenuAppearTime);
        DeathMenuCanvas.gameObject.SetActive(true);
        Instantiate(deathEffect, player.position, Quaternion.identity);
        //Time.timeScale = 0;
        player.gameObject.SetActive(false);
        
        died.died = false;
    }

    IEnumerator LoseCredit()
    {
        yield return new WaitForSeconds(3);
        LoseCreditCanvas.gameObject.SetActive(false);
        Reset();
        player.gameObject.SetActive(true);
        spaceCanvas.gameObject.SetActive(true);
    }


    public void Reset()
    {
        if (checkpoint.checkPoint == 0)
        {
            player.transform.position = startPos;
            theCamera.transform.position = cameraStartPos;
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
            player.transform.position = checkpoint2;
            theCamera.transform.position = cameraCheckPoint2;

        }
        if (checkpoint.checkPoint == 3)
        {
            player.transform.position = checkpoint3;
            theCamera.transform.position = cameraCheckPoint3;

        }

        if (checkpoint.checkPoint == 4)
        {
            player.transform.position = checkpoint4;
            theCamera.transform.position = cameraCheckPoint4;

        }
        DeathMenuCanvas.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().velocity = playerVelocity;
        
        Time.timeScale = 0;
        musicPlayed = true;
        died.died = false;
        lostLife = true;
        PlayerScript.playerGravityState = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator CountDown(int i, float j)
    {
        yield return new WaitForSeconds(j);
        countDownText.text = i.ToString();
        i--;
        if (j < 1)
        {
            j = j + 0.7f;
        }
        if (i >= 0)
        {
            StartCoroutine(CountDown(i, j));
        } else
        {
            i = 3;
            countDownText.text = i.ToString();
        }
    }
}