using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 _shootRaycastOrigin;
    public string _targetName;
    [SerializeField] private Animator _HandAnimator;
    [SerializeField] private Transform _shootpoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _range = 1000f;
    [SerializeField] private float _SpreadFactor = 0.1f;
    [SerializeField] private AudioSource _ShootAudio;
    [SerializeField] private float _currentBullets;
    [SerializeField] private float _maxBullets = 30f;

    private float _timer;


    private void Start()
    {
        _currentBullets = _maxBullets;

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && _timer >= _fireRate)
        {
            FireWeapon();
            //_HandAnimator.SetBool("Isshooting",true);
            _timer = 0;
        }
    }

    private void FireWeapon()
    {
        if (_currentBullets <= 0)
        {
            Debug.Log("Out of bullets!");
            return;
        }
        _shootRaycastOrigin = _shootpoint.position;
        Vector3 shootDirection = _shootpoint.forward;
        RaycastHit hit;
        shootDirection = shootDirection + _shootpoint.TransformDirection(new Vector3(Random.Range(-_SpreadFactor, _SpreadFactor), Random.Range(-_SpreadFactor, _SpreadFactor)));

        if (Physics.Raycast(_shootRaycastOrigin, shootDirection, out hit, _range))
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);

        }
        _currentBullets--;
        _ShootAudio.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_shootRaycastOrigin, _shootpoint.forward);
    }
}
