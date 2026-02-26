using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletMove : MonoBehaviour
    
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform _bulletTransform;
    [SerializeField] private Collider _bulletCollider;



    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 moveDirection = -_bulletTransform.forward.normalized;
        _bulletTransform.position += moveDirection * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
