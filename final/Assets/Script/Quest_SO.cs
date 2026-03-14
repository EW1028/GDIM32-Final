using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class Quest_SO : ScriptableObject
{
    public string _QuestName;
    public string _targetName;
    public int _targetAmount;
    public int _currentAmount;
}

//[System.Serializable]
//public class QuestInfo
//public string _QuestName;
//public string _targetName;
//public int _targetAmount;
// public int _currentAmount;






