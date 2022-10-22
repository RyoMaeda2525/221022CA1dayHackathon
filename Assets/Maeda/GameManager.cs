using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _enemyGenerationCount = 0;

    [SerializeField]
    private GameObject _gameClearPanel = null;

    [SerializeField]
    private GameObject _gameOverPanel = null;

    /// <summary>Enemyの討伐数</summary>
    private int _enemyCount = 0;

    private void Start()
    {
        GameOver();
    }

    /// <summary>Enemyの討伐数をカウントするプロパティ</summary>
    public void EnemyCout() 
    {
        _enemyCount++;
    }

    public void GameClear() { _gameClearPanel.SetActive(true); }

    public void GameOver() { _gameOverPanel.SetActive(true); }
}
