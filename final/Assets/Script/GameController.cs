using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;
    public event Action OnPointScored;

    public bool IsPlaying { get; private set; }
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

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        IsPlaying = true;
        score = 0;
        OnScoreChanged?.Invoke(score);
    }

    public void AddPoint()
    {
        if (!IsPlaying)
            return;
        score++;
        OnScoreChanged?.Invoke(score);
        OnPointScored?.Invoke();
    }

    public void GameOver()
    {
        if (!IsPlaying)
            return;
        IsPlaying = false;
        OnGameOver?.Invoke();

        Invoke(nameof(RestartGame), 1f);
    }
    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

