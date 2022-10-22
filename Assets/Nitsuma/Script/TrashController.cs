using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField]
    int _point = 1;

    public int Point { get => _point;}

    public void PointMove(Vector3 pos ,float speed)
    {
        this.transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }
}
