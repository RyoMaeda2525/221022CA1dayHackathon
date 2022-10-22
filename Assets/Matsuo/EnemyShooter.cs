using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    [SerializeField]
    GameObject _enemyBulletPrefab;

    GameObject _player;
    
    float shootTime;
    float _elapsedTime;


    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(_player.transform);
        Shoot();
    }

    void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > shootTime)
        {
            var obj = Instantiate(_enemyBulletPrefab);
            obj.transform.position = transform.position;
            _elapsedTime = 0;
        }
    }
}
