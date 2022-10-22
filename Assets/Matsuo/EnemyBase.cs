using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Cinemachine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CinemachineImpulseSource))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("最大体力")]
    int _enemyMaxHp = 10;
    [SerializeField, Tooltip("現在体力")]
    int _enemyHp;

    //NavMeshAgent _agent = null;
    GameManager _gameManager = null;
    CinemachineImpulseSource _impulseSource = default;


    public void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        //_agent = GetComponent<NavMeshAgent>();
        _enemyHp = _enemyMaxHp;
        //_agent.autoBraking = false;
    }

    public void Update()
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
        _impulseSource.GenerateImpulse(new Vector3(0, 0, -1));

    }

    /// <summary>
    /// エネミー死亡処理
    /// </summary>
    void Death()
    {
        if (_enemyHp <= 0)
        {
            _gameManager.EnemyCout();
            this.gameObject.SetActive(false);
        }

    }

}
