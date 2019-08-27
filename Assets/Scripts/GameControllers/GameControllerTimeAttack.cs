using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerTimeAttack : GameController
{
    public int DebugTime;

    float gameplayTimer;

    Text timeText;

    bool settling;
    public float settleAmount;
    float settleTimer;

    private void Start()
    {
        if (DataManager.getTime() == null)
        {
            gameplayTimer = DebugTime;
        }
        else
        {
            //Added 1 so the player gets the full x minutes
            gameplayTimer = 60 * int.Parse(DataManager.getTime()) + 1;
        }

        //Debug code

        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
        settling = false;
    }

    private void Update()
    {
        if(gameRunning)
        {
            if(playerPlaying)
            {
                gameplayTimer -= Time.deltaTime;

                timeText.text = "Time: " + Mathf.Floor(gameplayTimer / 60).ToString("00") + ":" + Mathf.Floor(gameplayTimer % 60).ToString("00");

                if (gameplayTimer <= 0)
                {
                    timeText.text = "Time Up!";
                    destroyAllRedBlocks();
                    playerPlaying = false;
                    settleTimer = Time.time + settleAmount;
                    settling = true;
                }
            }

            if(gameRunning && Time.time > settleTimer && settling)
            {
                gameRunning = false;
                addScore(countPlayerBlocksInScene());
                OnSessionEnd();
            }
        }

    }

    private int countPlayerBlocksInScene()
    {
        GameObject[] playerCubes = GameObject.FindGameObjectsWithTag("PlayerCube");
        return playerCubes.Length;
    }

    private void destroyAllRedBlocks()
    {
        GameObject[] enemyCubes = GameObject.FindGameObjectsWithTag("EnemyCube");

        foreach( GameObject enemyCube in enemyCubes)
        {
            Destroy(enemyCube);
        }
    }

}
