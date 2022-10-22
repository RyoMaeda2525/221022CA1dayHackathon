using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _enemyGenerationCount = 0; 

    /// <summary>Enemyの討伐数</summary>
    private int _enemyCount = 0; 

    /// <summary>Enemyの討伐数をカウントするプロパティ</summary>
    public int EnemyCout 
    {
        set { _enemyCount += value; }
    }

    public void GameClear() { }

    public void GameOver() { Debug.Log("GameOver"); }
}
