using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _HP = 3;

    private void Update()
    {
        Debug.Log(_HP);

    }

    public void TakeDamage(float damage)
    {
        _HP -= damage;

        if (GameController.Instance != null)
        {
            GameController.Instance.EnemyHit(this);
        }
        if (_HP <= 0)
        {
            if (GameController.Instance != null)
            {
                GameController.Instance.EnemyDead(this);
            }
            Destroy(gameObject);
        }
    }
}
