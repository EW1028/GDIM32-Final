using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _HP = 3;
    [SerializeField]private Weapon _weapon;
    [SerializeField] private TMP_Text _HPUI;
    private float _curentHP;

    private void Start()
    {
        _weapon.Onhit += TakeEnemyDamage;
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
            Destroy(gameObject);
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
