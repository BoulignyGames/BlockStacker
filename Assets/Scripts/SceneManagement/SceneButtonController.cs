using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneButtonController : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    public void nextScene()
    {
        DataManager.setTime(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
