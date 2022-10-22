using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void SceneSkip(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
    }

    public void StageSceneSelect(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Stage{value}");
    }

    void Update()
    {
        
    }
}
