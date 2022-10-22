using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField]
    float _speed = 3f;
    [SerializeField]
    int _point = 1;

    public int Point { get => _point;}

    public void PointMove(Vector3 pos)
    {
        this.transform.position = Vector3.MoveTowards(transform.position, pos, _speed * Time.deltaTime);
    }
}
