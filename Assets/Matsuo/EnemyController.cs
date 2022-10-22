using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Cinemachine;



public class EnemyController : EnemyBase
{

    [SerializeField, Tooltip("生成する汚れ")]
    GameObject _dropDustPrefab;
    [SerializeField, Tooltip("生成する間隔")]
    float _dropTime = 1f;
    [SerializeField, Tooltip("経過生成時間")]
    float _elapsedTime;

    Animator _anim = default;
    NavMeshAgent _agent = null;
    //GameManager _gameManager = null;

    [SerializeField, Tooltip("徘徊の中心地点")]
    Vector3 central;
    [SerializeField, Tooltip("移動範囲")]
    float _radius = 5;
    [SerializeField, Tooltip("設定した待機時間")]
    float _waitTime = 0.5f;
    [SerializeField, Tooltip("経過待機時間")]
    float _time = 0;


    new void Start()
    {
        base.Start();
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        //_impulseSource = GetComponent<CinemachineImpulseSource>();
        _agent.autoBraking = false;
        GotoNextPoint();
    }

    new void Update()
    {
        base.Update();
        if (Time.timeScale != 0 && this.gameObject.activeSelf)
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                StopHere();

            }
        }
        DropDast();
    }

    /// <summary>
    /// 一定間隔でゴミを生成する処理
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
