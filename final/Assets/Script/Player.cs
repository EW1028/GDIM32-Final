using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _Speed = 5.0f;
    [SerializeField] private Vector3 __playerVelocity;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        
        playermove();
    }
    private void playermove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 Dir = (_playerTransform.forward * verticalInput + _playerTransform.right * horizontalInput).normalized;
        __playerVelocity = Dir * _Speed;
        _playerRigidbody.velocity = __playerVelocity;
    }


}
