using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _targetNam;
    [SerializeField] private TMP_Text _targetNum;
    [SerializeField] private TMP_Text _currentNum;
    [SerializeField] private TMP_Text _questName;
    //[SerializeField] private Quest_SO QuestInfo;
    //[SerializeField] private QuestTarget QuestTarget;

    public void CreateQuest( int targetNum, string targetName, string QuestName)
    {
        _questName.text = QuestName;
        _targetNam.text = targetName;
        _targetNum.text = targetNum.ToString();
        _currentNum.text = "0";
    }

    public void questUpdate (int number, int targetNum)
    {
        _currentNum.text = number.ToString();
        if( number >= targetNum)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    
}
