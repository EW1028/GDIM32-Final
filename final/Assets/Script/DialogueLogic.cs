using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueLogic : MonoBehaviour
{
    private bool _isDialogueActive;
    private bool _waitForPlayerAnswer;
    private float _StartDistance = 4f;
    [SerializeField] private GameObject _TextUI;
    [SerializeField] private DialogueScript _StartDialogue;
    private DialogueScript _currentDialogue;
    private int _CurrentLine = 0;

    
    void Start()
    {
        _TextUI.SetActive(false);
        _currentDialogue = _StartDialogue;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, GameController.Instance.Player.transform.position) < _StartDistance)
        {
            _TextUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space) && !_waitForPlayerAnswer )
            {
                StartDialogue();
                Debug.Log("Start Dialogue");
            }
            //else if (!_isDialogueActive)
            //{
                
            //}
        }
    }

    private void StartDialogue()
    {
        _isDialogueActive = true;
        if(_CurrentLine < _currentDialogue._lines.Length)
        {
            GameController.Instance.DialogueUI.ShowDialogue(_currentDialogue._lines[_CurrentLine]);
            _CurrentLine++;
        }
        
    }

}