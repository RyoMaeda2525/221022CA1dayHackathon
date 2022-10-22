using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("�ő�̗�")]
    int _enemyMaxHp;
    [SerializeField, Tooltip("���ݑ̗�")]
    int _enemyHp;

    [SerializeField, Tooltip("�������鉘��")]
    GameObject _dropDustPrefab;

    Animator _anim = default;
    NavMeshAgent _agent = null;

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
        _enemyHp = _enemyMaxHp;
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        _agent.autoBraking = false;
        GotoNextPoint();
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            StopHere();
    }

    /// <summary>
    /// ���Ԋu�ŃS�~�𐶐����鏈��
    /// </summary>
    void DropDast()
    {

    }

    void GotoNextPoint()
    {
        //NavMeshAgent�̃X�g�b�v������
        _agent.isStopped = false;

        //�ڕW�n�_��X���AZ���������_���Ō��߂�
        float posX = Random.Range(-1 * _radius, _radius);
        float posZ = Random.Range(-1 * _radius, _radius);

        //CentralPoint�̈ʒu��PosX��PosZ�𑫂�
        Vector3 pos = central;
        pos.x += posX;
        pos.z += posZ;

        //NavMeshAgent�ɖڕW�n�_��ݒ肷��
        _agent.destination = pos;
    }

    void StopHere()
    {
        //NavMeshAgent���~�߂�
        _agent.isStopped = true;
        //�҂����Ԃ𐔂���
        _time += Time.deltaTime;

        //�҂����Ԃ��ݒ肳�ꂽ���l�𒴂���Ɣ���
        if (_time > _waitTime)
        {
            //�ڕW�n�_��ݒ肵����
            GotoNextPoint();
            _time = 0;
        }
    }

}
