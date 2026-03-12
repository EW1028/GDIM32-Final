using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 2)]
public class Quest_SO : ScriptableObject
{
    public List<QuestInfo> _questInfo;
}

[System.Serializable]

public class QuestInfo
{
    public string _targetName;
    public List <QuestTarget> _questTargets;
    
}
[System.Serializable]

public class QuestTarget
{
    public string _targetName;
    public int _targetAmount;
    public int _currentAmount;
}



 
