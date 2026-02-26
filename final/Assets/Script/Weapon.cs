using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 _shootRaycastOrigin;
    public string _targetName;
    //[SerializeField] private Animator _HandAnimator;
    [SerializeField] private Animator _GunAnimator;
    [SerializeField] private Transform _shootpoint;
    [SerializeField] private Transform _Bulletshootpoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _range = 1000f;
    [SerializeField] private float _SpreadFactor = 0.1f;
    [SerializeField] private AudioSource _ShootAudio;
    [SerializeField] private float _currentBullets;
    [SerializeField] private float _maxBullets = 30f;
    [SerializeField] private Object _BulletsPrefab;
    [SerializeField] private float _BulletSpeed;
    [SerializeField] private TMP_Text _Magnumber;
    [SerializeField] private TMP_Text _TotalMagNumber;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _reloadTimer;





    private float _timer;


    private void Start()
    {
        _currentBullets = _maxBullets;
       

    }

    
    void Update()
    {
       
            FireWeapon();
        Reload();

        _Magnumber.text = _currentBullets.ToString();
            _TotalMagNumber.text = _maxBullets.ToString();

    }

    private void FireWeapon()
    {
        _timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0)&&_timer >= _fireRate)
        {
            if (_currentBullets <= 0)
            {
                Debug.Log("Out of bullets!");
                return;
            }
            Instantiate(_BulletsPrefab, _Bulletshootpoint.transform.position,_Bulletshootpoint.transform.rotation * Quaternion.Euler(0, 180, 0));
           
            _shootRaycastOrigin = _shootpoint.position;
            Vector3 shootDirection = _shootpoint.forward;
            RaycastHit hit;
            shootDirection = shootDirection + _shootpoint.TransformDirection(new Vector3(Random.Range(_SpreadFactor, _SpreadFactor), Random.Range(-_SpreadFactor, _SpreadFactor)));

            if (Physics.Raycast(_shootRaycastOrigin, shootDirection, out hit, _range))
            {

                //Instantiate(_BulletsPrefab, _Bulletshootpoint.transform.position, _Bulletshootpoint.transform.rotation);
                //Bullet.GetComponent<Transform>().forward = shootDirection;
               // Bullet.GetComponent<Transform>().position = shootDirection* _BulletSpeed;
                Debug.Log("Hit: " + hit.transform.gameObject.name);

            }
            _currentBullets--;
            _ShootAudio.Play();
            _timer = 0;
            _GunAnimator.SetTrigger("Shoot");
            
        }
    }
    private void Reload()
    {
            _reloadTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.R)&&_reloadTimer>=_reloadTime)
        {
            _currentBullets = _maxBullets;
            Debug.Log("Reloaded!");
            _GunAnimator.SetTrigger("isReloading");
            _reloadTimer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_shootRaycastOrigin, _shootpoint.forward);
    }
}
