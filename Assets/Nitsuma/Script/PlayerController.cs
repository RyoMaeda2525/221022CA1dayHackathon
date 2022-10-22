using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _turnSpeed = 5f;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _muzzle;

    [SerializeField] Vector3 _inHaleArea;
    [SerializeField] Vector3 _inHaleAreaSize;
    [SerializeField] LayerMask _TrashLayer;
    [SerializeField] int _maxTrashGauge = 30;
    [SerializeField] int _shootLimit = 5;
    [SerializeField] int _currentTrash = 0;
    float _trashDis;
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
            if(_currentTrash < _shootLimit) { return; }
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(_muzzle.localPosition + _inHaleArea, _inHaleAreaSize);
    }
    private void InHale()
    {
        if (SarchArea().Length > 0)
        {
            foreach (var trash in SarchArea())
            {
                trash.PointMove(_muzzle.position);
                if (Vector3.Distance(trash.transform.position, _muzzle.position) <= _trashDis)
                {
                    _currentTrash = Mathf.Min(_currentTrash+trash.Point, _maxTrashGauge) ;
                    Destroy(trash.gameObject);
                }
            }
        }
    }
    private void Shoot()
    {
        _currentTrash -= _shootLimit;
        Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
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

    TrashController[] SarchArea()
    {
        List<TrashController> trashlist = new List<TrashController>();
        var array
            = Physics.OverlapBox(transform.position + _inHaleArea, _inHaleAreaSize, transform.rotation, _TrashLayer);

        foreach (var trash in array)
        {
            trashlist.Add(trash.GetComponent<TrashController>());
        }

        return trashlist.ToArray();
    }
}
