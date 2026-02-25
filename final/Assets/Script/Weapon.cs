using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 _shootRaycastOrigin;
    public string _targetName;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           FireWeapon(); 
        }
    }

    private void FireWeapon()
    {
        _shootRaycastOrigin = transform.position;
        Ray shootRay = new Ray(_shootRaycastOrigin, transform.forward);
        Physics.Raycast(shootRay, out RaycastHit hitInfo);
            if(hitInfo.collider != null)
            {
                Debug.Log("Hit: " + hitInfo.collider.name);
                _targetName = hitInfo.collider.name.ToString();
            }
            else
            {
                Debug.Log("Missed");
                _targetName = "None";
            }
    }
}
