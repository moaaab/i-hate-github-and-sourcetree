using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject player;
    public int meterScore = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreText;
    public IsDead died;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI highScoreTextGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        meterScore = ((int) player.transform.position.z) * 10 + 10;
        scoreText.text = meterScore.ToString();

        if (died.died && highScore < meterScore)
        {
            highScore = meterScore;
            highScoreText.text = highScore.ToString();
            highScoreTextGameOver.text = highScore.ToString();
        }
    }
}
