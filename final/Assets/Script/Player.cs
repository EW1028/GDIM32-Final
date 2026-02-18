using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] Transform _playerTransform;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        _playerTransform.position += moement;
    }
    
}
