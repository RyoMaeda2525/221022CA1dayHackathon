using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class SceneManager : MonoBehaviour
{
    /// <summary>引数と同じIndexのビルドシーンに飛ぶ</summary>
    /// <param name="value"></param>
    public void SceneValueSelect(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
    }

    /// <summary>引数と同じ名前のビルドシーンに飛ぶ</summary>
    /// <param name="sceneName"></param>
    public void SceneStringSelect(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    /// <summary>引数と同じIndexのStageシーンに飛ぶ</summary>
    /// <param name="value"></param>
    public void StageSceneSelect(int value) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Stage {value}");
    }
    
    /// <summary>次のStageに飛ぶ(StageSceneからしか使えない) </summary>
    public void NextStage() 
    {
        string value = Regex.Replace(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, @"[^0-9]", "");
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Stage {int.Parse(value) + 1}");
    }

    /// <summary>同じシーンを再生しなおす</summary>
    public void RepeatStage() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    /// <summary>アプリを閉じる</summary>
    public void CloseTheGame() 
    {
        if (Application.isEditor)
        EditorApplication.isPlaying = false;
        else
        Application.Quit();
    }
}
