using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _HP = 3;
    private Weapon _weapon;
    [SerializeField] private TMP_Text _HPUI;
    [SerializeField] private string _enemyName;
    private float _curentHP;
  
    public static Action<Enemy> enemyDeath;

    private void Start()
    {
        _weapon = GameController.Instance.Weapon;
        this.gameObject.tag = _enemyName;

        _curentHP = _HP;
    }

    private void Update()
    {
        
        _HPUI.text ="HP = "+ _curentHP.ToString();
        enemydestroy();
        

    }
    
    public void TakeEnemyDamage()
    {
        _curentHP -= _weapon._damageNum;
    }

    private void enemydestroy()
    {
        if (_curentHP <= 0)
        {
           
            enemyDeath?.Invoke(this);
            Destroy(gameObject,0.1f);
            _curentHP = _HP;

        }
    }

}
