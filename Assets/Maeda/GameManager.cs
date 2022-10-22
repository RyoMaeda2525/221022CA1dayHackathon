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

    /// <summary>Enemy�̓�����</summary>
    private int _enemyCount = 0;

    private void Start()
    {
        Time.timeScale = 1;
        _player = GameObject.Find("Player").gameObject;
    }

    /// <summary>Enemy�̓��������J�E���g����v���p�e�B</summary>
    public void EnemyCout()
    {
        _enemyCount++;
        if (_enemyGenerationCount == _enemyCount)
            GameClear();
    }

    public void GameClear() { _gameClearPanel.SetActive(true); _bgmPlay.BgmStop(); _sePlay.SePlay(3); Time.timeScale = 0;  }

    /// <summary>�Q�[���I�[�o�[���̎擾�ƃQ�[���I�[�o�[�ɂł���</summary>
    public void GameOver() { _gameOverPanel.SetActive(true); _player.SetActive(false); _bgmPlay.BgmPlay(1); Time.timeScale = 0;}
}
