using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("最大体力")]
    int _enemyMaxHp;
    [SerializeField, Tooltip("現在体力")]
    int _enemyHp;

    [SerializeField, Tooltip("生成する汚れ")]
    GameObject _dropDustPrefab;

    Animator _anim = default;
    NavMeshAgent _agent = null;

    [SerializeField, Tooltip("徘徊の中心地点")]
    Vector3 central;
    [SerializeField, Tooltip("移動範囲")]
    float _radius = 5;
    [SerializeField, Tooltip("設定した待機時間")]
    float _waitTime = 0.5f;
    [SerializeField, Tooltip("経過待機時間")]
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
    /// 一定間隔でゴミを生成する処理
    /// </summary>
    void DropDast()
    {

    }

    void GotoNextPoint()
    {
        //NavMeshAgentのストップを解除
        _agent.isStopped = false;

        //目標地点のX軸、Z軸をランダムで決める
        float posX = Random.Range(-1 * _radius, _radius);
        float posZ = Random.Range(-1 * _radius, _radius);

        //CentralPointの位置にPosXとPosZを足す
        Vector3 pos = central;
        pos.x += posX;
        pos.z += posZ;

        //NavMeshAgentに目標地点を設定する
        _agent.destination = pos;
    }

    void StopHere()
    {
        //NavMeshAgentを止める
        _agent.isStopped = true;
        //待ち時間を数える
        _time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (_time > _waitTime)
        {
            //目標地点を設定し直す
            GotoNextPoint();
            _time = 0;
        }
    }

}
