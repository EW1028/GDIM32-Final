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
            else if (!_isDialogueActive)
            {
                
            }
        }
        else
        {
            DialogueEnd();
        }
    }

    private void StartDialogue()
    {
        _isDialogueActive = true;
        Cursor.lockState = CursorLockMode.None;
        if(_CurrentLine < _currentDialogue._lines.Length)
        {
            GameController.Instance.DialogueUI.ShowDialogue(_currentDialogue._lines[_CurrentLine]);
            _CurrentLine++;
        }
        else if(_currentDialogue._playerReplyOptions != null && _currentDialogue._playerReplyOptions.Length > 0)
        {
            _waitForPlayerAnswer = true;
            GameController.Instance.DialogueUI.ShowAnswer(_currentDialogue._playerReplyOptions);
        }
        else
        {
            DialogueEnd();
        }
        
    }
    private void DialogueEnd()
    {
         _TextUI.SetActive(false);
        _isDialogueActive = false;
        _waitForPlayerAnswer = false;
        _CurrentLine = 0;
        _currentDialogue = _StartDialogue;
        GameController.Instance.DialogueUI.DialogueHide();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AnswerSelection(int Option)
    {
        Debug.Log("Player selected option: " + Option);
        // Implement logic based on player's choice
        _CurrentLine = 0; // Reset line index for the next dialogue
        _waitForPlayerAnswer = false;
        _currentDialogue = _currentDialogue._npcReplies[Option]; // Move to the next dialogue based on player's choice
        StartDialogue();

    }
}