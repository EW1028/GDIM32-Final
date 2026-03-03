using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _HP = 3;
    [SerializeField]private Weapon _weapon;

    private void Start()
    {
        _weapon.Onhit += TakeEnemyDamage;
    }

    private void Update()
    {
        //Debug.Log(_HP);
        enemydestroy();

    }
    
    public void TakeEnemyDamage()
    {
        _HP -= _weapon._damageNum;
    }

    private void enemydestroy()
    {
        if (_HP <= 0)
        {
            
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
