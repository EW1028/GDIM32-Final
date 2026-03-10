using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private bool _isDialogueActive;
    private bool _waitForPlayerAnswer;
    private float _StartDistance;
    void Update()
    {
        if(Vector3.Distance(transform.position, GameController.Instance.Player.transform.position) < _StartDistance)
        {
            // Trigger dialogue
        }
    }

}