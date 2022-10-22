using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    [SerializeField] string _wallTag;
    [SerializeField] string _enemyTag;
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
        if (other.tag == _wallTag || other.tag == _enemyTag)
        {
            if(other.tag == _enemyTag)
            {
                if (other.gameObject.GetComponent<EnemyController>())
                {
                    other.gameObject.GetComponent<EnemyController>().GetDamage(_damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
