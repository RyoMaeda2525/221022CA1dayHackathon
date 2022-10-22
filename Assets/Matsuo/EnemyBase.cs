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

    [SerializeField, Tooltip("�������鉘��")]
    GameObject _dropDustPrefab;
    [SerializeField, Tooltip("��������Ԋu")]
    float _dropTime = 1f;
    [SerializeField, Tooltip("�o�ߐ�������")]
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
    /// �_���[�W����
    /// </summary>
    /// <param name="damage"></param>
    void GetDamage(int damage)
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
