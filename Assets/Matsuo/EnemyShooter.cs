using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    [SerializeField]
    GameObject _enemyBulletPrefab;
    [SerializeField]
    Transform[] _muzzles;
    GameObject _player;

    [SerializeField]
    float shootTime;
    float _elapsedTime;
    [SerializeField]
    float _bulletSpeed;

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
            for(int i = 0; i < _muzzles.Length; i++)
            {
                // ’e‚ð”­ŽË‚·‚éêŠ‚ðŽæ“¾
                Vector3 bulletPosition = _muzzles[i].position;
                GameObject newBall = Instantiate(_enemyBulletPrefab, bulletPosition, transform.rotation);
                newBall.GetComponent<Rigidbody>().velocity = _bulletSpeed * _muzzles[i].forward;
                Destroy(newBall, 5f);
            }

            _elapsedTime = 0;
        }
    }

    /// <summary>
    /// ’e‚Ì”­ŽË
    /// </summary>
    private void LauncherShot()
    {

    }
}
