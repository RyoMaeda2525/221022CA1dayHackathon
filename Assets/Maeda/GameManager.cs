using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _enemyGenerationCount = 0; 

    /// <summary>Enemy�̓�����</summary>
    private int _enemyCount = 0; 

    /// <summary>Enemy�̓��������J�E���g����v���p�e�B</summary>
    public void EnemyCout() 
    {
        _enemyCount++;
    }

    public void GameClear() { }

    public void GameOver() { Debug.Log("GameOver"); }
}
