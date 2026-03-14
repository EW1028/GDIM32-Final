using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]
public class DialogueScript : ScriptableObject
{
    public string[] _lines;
    public string[] _playerReplyOptions;
    public DialogueScript[] _npcReplies;
    public Quest_SO _Quest;
    public bool _isQuestStart;
    
}
