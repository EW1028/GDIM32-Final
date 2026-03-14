using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

//using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _Speed = 5.0f;
    [SerializeField] private Vector3 __playerVelocity;
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private float _jump = 10;
    [SerializeField] private Collider _playercollider;
    private bool _isGround;
    Vector3 Dir;
    Vector3 Velocity;
    private bool _isjumping;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {      
        playermove();
        jump();
    }
    private void FixedUpdate()
    {
        if (_isjumping)
        {
            _isjumping = false;
            Velocity.y = _jump;
            //Debug.Log("jump");
        }
        _playerRigidbody.velocity = Velocity;
        
    }
    private void playermove()
    {
        Dir = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            Dir += _playerTransform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Dir += -_playerTransform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Dir += _playerTransform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Dir += -_playerTransform.forward;
        }

        Velocity = Dir.normalized * _Speed;
        Velocity.y = _playerRigidbody.velocity.y;
    }

    private void  jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& _isGround == true)
        {
            _isjumping = true;
            _isGround = false;
        }
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            _isGround = true;
        }
    }

    private void enemycreate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(_EnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
