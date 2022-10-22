using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingModelController : MonoBehaviour
{
    [SerializeField]
    Transform _targetTransform;
    Vector3 _destinaition;
    [SerializeField]
    float _distance;
    [SerializeField]
    float _rate;
    [SerializeField]
    float _moveSpeed;
    public Transform TargetTransform { get => _targetTransform; set => _targetTransform = value; }


    void Update()
    {
        if(!_targetTransform)
            return;
        else
        {
            SetDestinaition(_targetTransform.position);
        }
    }

    private void FixedUpdate()
    {
        if(_targetTransform)
        {
            var dir = (GetDestinaition() - transform.position).normalized;
            dir.y = 0;
            transform.position = Vector3.Lerp(this.gameObject.transform.position, _targetTransform.position - dir * _distance, Time.deltaTime * _rate);
            Quaternion setRotaition = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, setRotaition, 120f * 0.1f * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject,0.5f);
        }

    }

    public void SetDestinaition(Vector3 position)
    {
        _destinaition = position;
    }

    public Vector3 GetDestinaition()
    {
        return _destinaition;
    }
}
