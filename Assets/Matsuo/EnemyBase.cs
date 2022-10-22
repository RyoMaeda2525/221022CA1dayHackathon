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

    NavMeshAgent _agent = null;
    GameManager _gameManager = null;


    void Start()
    {
        _gameManager = GameObject.Find("GameObject").GetComponent<GameManager>();
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
    public void GetDamage(int damage)
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
