using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
   [Header("Audio Clips")]
   public AudioClip backgroundmorningSound;
   public AudioClip backgroundeveningSound;
   public AudioClip scoreSound;
   public AudioClip hitSound;
   public AudioClip shootSound;
   public AudioClip talkSound;
   public AudioClip enemyDeadSound;
   

   private AudioSource audioSource;
   private void Awake()
   {
    audioSource = GetComponent<AudioSource>();
   }

   private void OnEnable()
   {
    if (GameController.Instance == null)
    return;
     GameController.Instance.OnShoot += HandleShoot;
     GameController.Instance.OnTalkStart  += HandleTalkStart;
     GameController.Instance.OnEnemyHit += HandleEnemyHit;
     GameController.Instance.OnEnemyDead += HandleEnemyDead;
     GameController.Instance.OnScoreChanged += HandlePointScored;
   }

   private void OnDisable()
   {
    if (GameController.Instance == null)
    return;
        GameController.Instance.OnShoot -= HandleShoot;
        GameController.Instance.OnTalkStart  -= HandleTalkStart;
        GameController.Instance.OnEnemyHit -= HandleEnemyHit;
        GameController.Instance.OnEnemyDead -= HandleEnemyDead;
        GameController.Instance.OnScoreChanged -= HandlePointScored;
   }

   private void HandleShoot()
   {
    if (shootSound != null)
    audioSource.PlayOneShot(shootSound);
   }
   private void HandleTalkStart()
   {
    if (talkSound != null)
    audioSource.PlayOneShot(talkSound);
   }
   
   private void HandleEnemyHit(Enemy enemy)
   {
    if (hitSound != null)
    audioSource.PlayOneShot(hitSound);
   }
    private void HandleEnemyDead(Enemy enemy)
   {
    if (enemyDeadSound != null)
    audioSource.PlayOneShot(enemyDeadSound);
   }
    private void HandlePointScored(int newScore)
    {
    if (scoreSound != null)
    audioSource.PlayOneShot(scoreSound);
    }

    public void PlayBackgroundMorning()
    {
        if (backgroundmorningSound != null)
        {
            audioSource.clip = backgroundmorningSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}


