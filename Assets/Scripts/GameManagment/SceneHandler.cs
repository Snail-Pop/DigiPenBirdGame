/*
 * Name: Tayvian Eberle
 * Date: 10/4/2022
 * Desc: Contains a function that changes the current scene to the scene chosen in editor. Meant to work with UnityEvents.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
