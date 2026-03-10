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
    public Player Player;
    public CameraController CameraController;
    [SerializeField] private GameObject _gamestop;

    public bool IsPlaying { get; private set; } = true;
    private int score = 0;

    private bool _Ispause = false;

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
    public void PauseGame()
    {
        _gamestop.SetActive(true);
       Time.timeScale = 0f;
        _Ispause = true;
    }
    public void ResumeGame()
    {
        _gamestop.SetActive(false);
        Time.timeScale = 1f;
        _Ispause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_Ispause)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();
                
            }
        }
    }
}