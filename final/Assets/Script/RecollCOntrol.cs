using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecollControl : MonoBehaviour
{
    [SerializeField] private float _X = -3f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _returnSpeed = 5f;
    private Weapon _weapon;

    private float _targetRotation;
    private float _currentRotation;


 

    void Start()
    {
      // _weapon.OnShoot += Fire;
    }
    void Update()
    {
        _targetRotation = Mathf.Lerp(_targetRotation, _X, Time.deltaTime * _returnSpeed);
        _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, Time.deltaTime * _speed);
        transform.localRotation = Quaternion.Euler(_currentRotation,transform.localEulerAngles.y,transform.localEulerAngles.z);
    }
    public void Fire()
    {
        _targetRotation += _X;
    }
}
