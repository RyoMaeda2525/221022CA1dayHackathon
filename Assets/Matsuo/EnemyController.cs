using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Cinemachine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CinemachineImpulseSource))]

public class EnemyController : MonoBehaviour
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
    CinemachineImpulseSource _impulseSource = default;

    [SerializeField, Tooltip("�p�j�̒��S�n�_")]
    Vector3 central;
    [SerializeField, Tooltip("�ړ��͈�")]
    float _radius = 5;
    [SerializeField, Tooltip("�ݒ肵���ҋ@����")]
    float _waitTime = 0.5f;
    [SerializeField, Tooltip("�o�ߑҋ@����")]
    float _time = 0;


    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _enemyHp = _enemyMaxHp;
        _agent.autoBraking = false;
        GotoNextPoint();
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            StopHere();

        }
        DropDast();
        Death();
    }

    /// <summary>
    /// ���Ԋu�ŃS�~�𐶐����鏈��
    /// </summary>
    void DropDast()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _dropTime)
        {
            var obj = Instantiate(_dropDustPrefab);
            obj.transform.position = transform.position;
            _elapsedTime = 0;
        }
    }

    /// <summary>
    /// �_���[�W����
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamage(int damage)
    {
        _enemyHp -= damage;
        _impulseSource.GenerateImpulse(new Vector3(0, 0, -1));
    }

    /// <summary>
    /// �G�l�~�[���S����
    /// </summary>
    void Death()
    {
        if(_enemyHp <= 0)
        {
            _gameManager.EnemyCout();
            Destroy(gameObject);
        }

    }

    void GotoNextPoint()
    {
        _agent.isStopped = false;
        float posX = Random.Range(-1 * _radius, _radius);
        float posZ = Random.Range(-1 * _radius, _radius);

        Vector3 pos = central;
        pos.x += posX;
        pos.z += posZ;

        _agent.destination = pos;
    }

    void StopHere()
    {
        _agent.isStopped = true;
        _time += Time.deltaTime;

        if (_time > _waitTime)
        {
            GotoNextPoint();
            _time = 0;
        }
    }

}
