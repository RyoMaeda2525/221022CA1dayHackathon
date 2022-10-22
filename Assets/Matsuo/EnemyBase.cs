using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("最大体力")]
    int _enemyMaxHp = 10;
    [SerializeField, Tooltip("現在体力")]
    int _enemyHp;

    [SerializeField, Tooltip("生成する汚れ")]
    GameObject _dropDustPrefab;
    [SerializeField, Tooltip("生成する間隔")]
    float _dropTime = 1f;
    [SerializeField, Tooltip("経過生成時間")]
    float _elapsedTime;

    Animator _anim = default;
    NavMeshAgent _agent = null;
    GameManager _gameManager = null;


    void Start()
    {
        //_gameManager = GameObject.Find("GameObject").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyHp = _enemyMaxHp;
        _agent.autoBraking = false;
    }

    void Update()
    {
        Death();
    }


    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    void GetDamage(int damage)
    {
        _enemyHp -= damage;
    }

    /// <summary>
    /// エネミー死亡処理
    /// </summary>
    void Death()
    {
        if (_enemyHp <= 0)
        {
            //_gameManager.EnemyCout();
            Destroy(gameObject);
        }

    }

}
