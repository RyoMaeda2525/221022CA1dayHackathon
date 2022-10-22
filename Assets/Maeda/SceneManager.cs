using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void SceneValueSelect(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
    }

    public void StageSceneSelect(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Stage {value}");
    }

    public void SceneStringSelect(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void CloseTheGame() 
    {
        if (Application.isEditor)
        EditorApplication.isPlaying = false;
        else
        Application.Quit();
    }
}
