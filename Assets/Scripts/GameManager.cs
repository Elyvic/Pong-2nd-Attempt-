using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerOneScore = 0, playerTwoScore = 0;

    public int ScoreLimit;

    [HideInInspector]
    public string winner;

    public GameObject ball;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI winnerText;

    public GameObject panel;

    


    private void Start()
    {
        Time.timeScale = 1f;
        Instantiate(ball, new Vector3(0f,0f,0f), Quaternion.identity);

        score1.SetText("0");
        score2.SetText("0");
    }


    public void PlayerOne()
    {
        playerOneScore++;

        string score = playerOneScore.ToString();
        score1.SetText(score);
        Debug.Log("player 1 " + playerOneScore);
        Instantiate(ball, new Vector3(0f, 0f, 0f), Quaternion.identity);

        if(playerOneScore == ScoreLimit)
        {
            Win("Player 1 Win");
        }
    }

    public void PlayerTwo()
    {
        playerTwoScore++;
        string score = playerTwoScore.ToString();
        score2.SetText(score);
        
        Instantiate(ball, new Vector3(0f, 0f, 0f), Quaternion.identity);

        if (playerTwoScore == ScoreLimit)
        {
            Win("Player 2 Win");
        }
    }
    public void Win(string winnerName)
    {
        Time.timeScale = 0f;

        panel.SetActive(true);
        winnerText.SetText(winnerName);
        Debug.Log(winnerName);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
