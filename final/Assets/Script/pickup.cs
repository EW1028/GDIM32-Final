using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private float _startdistance = 3.0f;
    [SerializeField] GameObject _InfoUI;
    //[SerializeField] GameObject _object;
    //private bool _isPickup = false;
    public static Action<pickup> OnPickup;



    private void Update()
    {
        if (Vector3.Distance(transform.position, GameController.Instance.Player.transform.position) <= _startdistance )
        {
            _InfoUI.SetActive(true);
            if (Input.GetKeyUp(KeyCode.F))
            {
                OnPickup?.Invoke(this);
                //_isPickup=true;
                _InfoUI.SetActive(false);
                this.gameObject.SetActive(false);
                
            }
        }
        else
        {
           _InfoUI.SetActive(false);
        }

    }
}
