using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectExit : MonoBehaviour
{
    GameController gameController;
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("EnemyCube"))
        {
            gameController.addScore(10);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
