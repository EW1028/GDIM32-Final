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
    //[SerializeField] private QuestTarget _questinfo;
    [SerializeField] private GameObject _questBoard;
    [SerializeField] private RectTransform _questUI;
    [SerializeField] private DialogueScript _NewDialogueStart;
    private DialogueScript _currentDialogue;
    private int _CurrentLine = 0;
    private string _questtext;
    private RectTransform _lastSpawnQuest;
    //private float space = 10f;
    private bool _isQuestcreateing = true;
    

    



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
            if(Input.GetKeyDown(KeyCode.E) && !_waitForPlayerAnswer )
            {
                StartDialogue();
                //Debug.Log("Start Dialogue");
            }
            else if (_isDialogueActive == false)
            {
                WhenFinishQUests();
            }
        }
        else
        {
            DialogueEnd();
            WhenFinishQUests();
        }
        
    }

    private void StartDialogue()
    {
        _isDialogueActive = true;
        Cursor.lockState = CursorLockMode.None;
        if(GameController.Instance.Player != null)
        {
           GameController.Instance.Weapon.enabled = false;
        }
        if (_currentDialogue._Quest != null && _isQuestcreateing == true)
        {
            GameController.Instance.QuestUI.CreateQuest(_currentDialogue._Quest._targetAmount, _currentDialogue._Quest._targetName, _currentDialogue._Quest._QuestName);
            DiaSpawnQuests();
            _isQuestcreateing = false;

        }
        //OnDisable();
        if (_CurrentLine < _currentDialogue._lines.Length)
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
        GameController.Instance.Weapon.enabled = true;
        _isQuestcreateing = true;
    }
    public void AnswerSelection(int Option)
    {
        _CurrentLine = 0; 
        _waitForPlayerAnswer = false;
        _currentDialogue = _currentDialogue._npcReplies[Option]; 
        StartDialogue();
    }
    public void DiaSpawnQuests()
    {
       
        GameController.Instance.QuestManager.SpawnQuests();
        _isQuestcreateing = false;
    }
    private void WhenFinishQUests()
    {
        if (GameController.Instance.QuestManager.__finishQuestNUM > 0)
        {
            _currentDialogue = _NewDialogueStart;
        }
        else if(GameController.Instance.QuestManager.__finishQuestNUM <= 0)
        {
            _currentDialogue = _StartDialogue;
        }

        }
    }