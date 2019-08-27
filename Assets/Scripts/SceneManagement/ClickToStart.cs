using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    public string sceneName;
    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
