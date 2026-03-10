using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour
{
   //[SerializeField] private Camera _mainCamera;

    private void Update()
    {

        transform.LookAt(GameController.Instance.CameraController.transform.position);
        transform.Rotate(0, 180, 0);
    }

}
