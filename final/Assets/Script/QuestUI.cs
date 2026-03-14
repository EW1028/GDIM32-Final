using System;
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
    private int _currentNumber;
    private string _targetName;
    public static Action<QuestUI> QuestDestroy ;
    //[SerializeField] private Quest_SO QuestInfo;
    //[SerializeField] private QuestTarget QuestTarget;

    public void CreateQuest( int targetNum, string targetName, string QuestName)
    {
        _questName.text = QuestName;
        _targetNam.text = targetName;
        //_targetName = targetName;
        _targetNum.text = targetNum.ToString();
        _currentNum.text = "0";
        //Debug.Log(_targetName);
    }

    
    private void Start()
    {
        _targetName = _targetNam.text;
        Enemy.enemyDeath += OnEnemyDeath;
        // Debug.Log(_targetName);
    }
    private void Update()
    {
        checking();
    }
    void OnEnemyDeath(Enemy enemy)
    {
        Debug.Log(enemy.tag);
        if(enemy.tag == _targetName)
        {
            _currentNumber += 1;
            _currentNum.text = _currentNumber.ToString(); 
        }
    }
    public void checking()
    {
        if (_currentNum.text == _targetNum.text)
        {
            // Debug.Log("same");
            //QuestDestroy?.Invoke(this);

            Destroy(gameObject, 0.1f);
        }
    }
}
