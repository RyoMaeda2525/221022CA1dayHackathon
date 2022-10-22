using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("�ő�̗�")]
    int _enemyMaxHp = 10;
    [SerializeField, Tooltip("���ݑ̗�")]
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
    /// �_���[�W����
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamage(int damage)
    {
        _enemyHp -= damage;
    }

    /// <summary>
    /// �G�l�~�[���S����
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
