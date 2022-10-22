using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _turnSpeed = 5f;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzle;
    float _h, _v;
    Vector3 _dir;

    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _dir = new Vector3(_h, 0, _v);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else if (Input.GetMouseButton(1))
        {
            InHale();
        }
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void InHale()
    {
        throw new NotImplementedException();
    }
    private void Shoot()
    {
        Instantiate(_bulletPrefab,_muzzle.position , _muzzle.rotation);
    }
    private void Move()
    {
        if (_dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * _turnSpeed);
        }
        _rb.velocity = _dir.normalized * _speed;
    }
}
