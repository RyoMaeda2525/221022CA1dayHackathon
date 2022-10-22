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

    [SerializeField]
    private GameObject _player = null;

    [SerializeField]
    BGMPlay _bgmPlay = null;

    [SerializeField]
    SEPlay _sePlay = null;

    /// <summary>Enemyの討伐数</summary>
    private int _enemyCount = 0;

    private void Start()
    {
        Time.timeScale = 1;
        _player = GameObject.Find("Player").gameObject;
    }

    /// <summary>Enemyの討伐数をカウントするプロパティ</summary>
    public void EnemyCout()
    {
        _enemyCount++;
        if (_enemyGenerationCount == _enemyCount)
            GameClear();
    }

    public void GameClear() { _gameClearPanel.SetActive(true); _bgmPlay.BgmStop(); _sePlay.SePlay(3); Time.timeScale = 0;  }

    /// <summary>ゲームオーバーかの取得とゲームオーバーにできる</summary>
    public void GameOver() { _gameOverPanel.SetActive(true); _player.SetActive(false); _bgmPlay.BgmPlay(1); Time.timeScale = 0;}
}
