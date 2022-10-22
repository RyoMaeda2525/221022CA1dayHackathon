using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

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

    /// <summary>Ÿ‚ÌStage‚É”ò‚Ô(StageScene‚©‚ç‚µ‚©g‚¦‚È‚¢) </summary>
    public void NextStage() 
    {
        string value = Regex.Replace(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, @"[^0-9]", "");
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Stage {int.Parse(value) + 1}");
    }

    /// <summary>“¯‚¶ƒV[ƒ“‚ğÄ¶‚µ‚È‚¨‚·</summary>
    public void RepeatStage() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void CloseTheGame() 
    {
        if (Application.isEditor)
        EditorApplication.isPlaying = false;
        else
        Application.Quit();
    }
}
