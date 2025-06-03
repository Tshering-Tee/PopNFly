using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreUi;
    public Text highScore;
    public GameObject player;
    private int playerScore = 0;
    private int savedScore;
    private GameObject triggerBasket;
    private Rigidbody2D playerRb;

    private bool initialized = false;

    void Start()
    {
        savedScore = PlayerPrefs.GetInt("highScore", 0);
        highScore.text = savedScore.ToString();
        scoreUi.text = "0";
    }

    public void UpdatePlayerScore(int score)
    {
        playerScore += score;
        scoreUi.text = playerScore.ToString();

        if (playerScore > savedScore)
        {
            savedScore = playerScore;
            PlayerPrefs.SetInt("highScore", savedScore);
            PlayerPrefs.Save();
            highScore.text = savedScore.ToString();
        }


    }
}