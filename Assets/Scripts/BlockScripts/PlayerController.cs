using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    bool objectAlreadyAtSpawn = false;
    [Tooltip("Decrease to allow players to spawn in between cracks and vice versa")]
    public float sideLengthOfCollider;
    BoxCollider checkerCollider;

    [Header("Spawnable Player Blocks")]
    public GameObject[] blocks;

    public float spawnRate;
    float spawnTimer;

    GameController gameController;

    public float bulletTimeLeft;
    public float startBulletTime;
    bool bulletTimeActive;
    Text bulletTimeText;

    private void Start()
    {
        objectAlreadyAtSpawn = false;
        checkerCollider = GetComponent<BoxCollider>();
        checkerCollider.size = new Vector3(sideLengthOfCollider, sideLengthOfCollider, sideLengthOfCollider);
        spawnTimer = spawnRate + Time.time;

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        bulletTimeText = GameObject.FindGameObjectWithTag("BulletTimeText").GetComponent<Text>();
        bulletTimeLeft = startBulletTime;
        bulletTimeActive = false;
        bulletTimeText.text = "Bullet Time Left: " + (int)bulletTimeLeft;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCube") || other.CompareTag("EnemyCube") || other.CompareTag("Environment"))
        {
            objectAlreadyAtSpawn = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerCube") || other.CompareTag("EnemyCube") || other.CompareTag("Environment"))
        {
            objectAlreadyAtSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCube") || other.CompareTag("EnemyCube") || other.CompareTag("Environment"))
        {
            objectAlreadyAtSpawn = false;
        }
    }

    private void Update()
    {
        checkerCollider.size = new Vector3(sideLengthOfCollider, sideLengthOfCollider, sideLengthOfCollider);

        Vector3 pos = Input.mousePosition;
        pos.z = Camera.main.gameObject.transform.position.z + (Camera.main.transform.position.z * -2);

        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(pos);

        gameObject.transform.position = spawnPos;

        if(!objectAlreadyAtSpawn && Input.GetButtonDown("Fire1") && Time.time>spawnTimer && gameController.playerPlaying)
        {
            Instantiate(blocks[0], transform.position,transform.rotation );
            spawnTimer += spawnRate;
        }

        if(gameController.playerPlaying && Input.GetButtonDown("Fire2") && !bulletTimeActive)
        {
            Time.timeScale = .5f;
            bulletTimeActive = true;
            bulletTimeText.text = "Bullet Time Left: " + (int)bulletTimeLeft;
        }

        if (bulletTimeActive)
        {
            bulletTimeLeft -= Time.deltaTime;
            bulletTimeText.text = "Bullet Time Left: " + (int)bulletTimeLeft;
        }

        if (!gameController.playerPlaying || Input.GetButtonUp("Fire2") || bulletTimeLeft <= 0)
        {
            Time.timeScale = 1f;
            bulletTimeActive = false;
            bulletTimeText.text = "Bullet Time Left: " + (int)bulletTimeLeft;
        }
    }

}
