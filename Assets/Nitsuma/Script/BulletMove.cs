using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] string _tag;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //オブジェクトのアクティブを切り替えるかも
        if (other.tag == _tag) { Destroy(gameObject); }
    }
}
