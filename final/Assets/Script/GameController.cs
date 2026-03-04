using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public event Action OnShoot;
    public event Action OnTalkStart;
    public event Action OnTalkEnd;

    public event Action<Enemy> OnEnemyHit;
    public event Action<Enemy> OnEnemyDead;

    public event Action<int> OnScoreChanged;

    public Weapon Weapon;
    public UI UI;

    public bool IsPlaying { get; private set; } = true;
    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Shoot()
    {
        if(!IsPlaying)
            return;
        OnShoot?.Invoke();
    }

    public void TalkStart()
    {
        IsPlaying = false;
        OnTalkStart?.Invoke();
    }

    public void TalkEnd()
    {
        IsPlaying = true;
        OnTalkEnd?.Invoke();
    }

    public void EnemyHit(Enemy enemy)
    {
        if (!IsPlaying)
            return;
        OnEnemyHit?.Invoke(enemy);
    }
    public void EnemyDead(Enemy enemy)
    {
        if (!IsPlaying)
            return;
        OnEnemyDead?.Invoke(enemy);
        AddScore(1);
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }
    
}