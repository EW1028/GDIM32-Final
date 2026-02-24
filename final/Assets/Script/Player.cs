using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    [SerializeField] Transform _playerTransform;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 moement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        //_playerTransform.position += moement;
        playermove();
    }
    private void playermove()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        _playerTransform.position += direction * moveSpeed * Time.deltaTime;    
    }
    
}
