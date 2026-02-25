using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 3;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (GameController.Instance != null)
        {
            GameController.Instance.EnemyHit(this);
        }
        if (hp <= 0)
        {
            if (GameController.Instance != null)
            {
                GameController.Instance.EnemyDead(this);
            }
            Destroy(gameObject);
        }
    }
}
