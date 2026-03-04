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
    private float _curentHP;
    //public delegate void deathaction();
    public static Action<Enemy> 敌人死亡;

    private void Start()
    {
        _weapon = GameController.Instance.Weapon;
       // _weapon.Onhit += TakeEnemyDamage;
        _curentHP = _HP;
    }

    private void Update()
    {
        //Debug.Log(_HP);
        enemydestroy();
        _HPUI.text ="HP = "+ _curentHP.ToString();

    }
    
    public void TakeEnemyDamage()
    {
        _curentHP -= _weapon._damageNum;
    }

    private void enemydestroy()
    {
        if (_curentHP <= 0)
        {
            _curentHP = _HP;
            敌人死亡?.Invoke(this);
            Destroy(gameObject,0.1f);

        }
    }

    //public void TakeDamage(float damage)
   // {
        //_HP -= damage;

        //if (GameController.Instance != null)
        //{
          // GameController.Instance.EnemyHit(this);
       // }
       // if (_HP <= 0)
       // {
          // if (GameController.Instance != null)
          //  {
           //     GameController.Instance.EnemyDead(this);
          //  }
          //  Destroy(gameObject);
       // }
    //}
}
