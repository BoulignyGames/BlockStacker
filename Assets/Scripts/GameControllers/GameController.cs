using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //State machine
    public bool gameRunning;
    public bool playerPlaying;

    GameObject[] environmentObjects;
    GameObject[] playerSpawner;
    GameObject[] enemySpawner;

    int score;
    Text scoreText;

    GameObject playArea;

    private void Awake()
    {
        environmentObjects = GameObject.FindGameObjectsWithTag("Environment");
        playerSpawner = GameObject.FindGameObjectsWithTag("PlayerSpawner");
        enemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");

        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();

        gameRunning = true;
        playerPlaying = true;
        score = 0;

        scoreText.text = "Score: " + score;
    }

    protected void OnSessionEnd()
    {
        DataManager.sendScore(score);
    }

    public void addScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = "Score: " + score;
    }

    public void subScore(int toSub)
    {
        score -= toSub;
        scoreText.text = "Score: " + score;
    }

}
