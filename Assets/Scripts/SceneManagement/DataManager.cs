using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    GameObject gameController;
    private static int score;
    private static string time;

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void sendScore(int newScore)
    {
        score = newScore;
    }

    public static void setTime(string newTime)
    {
        time = newTime;
    }

    public static string getTime()
    {
        return time;
    }

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
}
