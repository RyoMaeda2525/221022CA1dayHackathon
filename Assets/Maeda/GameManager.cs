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

    /// <summary>Enemy�̓�����</summary>
    private int _enemyCount = 0;

    private void Start()
    {
        GameOver();
    }

    /// <summary>Enemy�̓��������J�E���g����v���p�e�B</summary>
    public void EnemyCout() 
    {
        _enemyCount++;
    }

    public void GameClear() { _gameClearPanel.SetActive(true); }

    public void GameOver() { _gameOverPanel.SetActive(true); }
}
