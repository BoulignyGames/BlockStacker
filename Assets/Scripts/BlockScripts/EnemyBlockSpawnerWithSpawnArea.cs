using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockSpawnerWithSpawnArea : MonoBehaviour
{
    [Header("Enemy Block Control")]
    //How long the delay between enemy placing blocks is
    public float delayBetweenSpawningEnemyBlocks;
    //The actual timer
    float enemyBlocksDelayTimer;
    //The box that will be spawned
    public GameObject enemyBox;
    //The game controller so we can get the list of current spawned blocks
    GameController gameController;

    public GameObject spawnArea;
    Bounds spawnAreaBounds;
    public GameObject Plank;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        spawnAreaBounds = spawnArea.GetComponent<Collider>().bounds;

        Transform plank = Plank.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn enemy blocks
        if (Time.time > enemyBlocksDelayTimer && gameController.playerPlaying)
        {
            //spawn the box based on the random values and a predetermined zposition
            Instantiate(enemyBox, RandomPointInBounds(spawnAreaBounds), Quaternion.identity);

            //increase the delay timer for the next spawned block
            enemyBlocksDelayTimer = Time.time + delayBetweenSpawningEnemyBlocks;
        }
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0f
        );
    }
}


