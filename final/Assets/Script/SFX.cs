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
   

   private AudioSource audioSource;
   private void Awake()
   {
    audioSource = GetComponent<AudioSource>();
   }

   private void OnEnable()
   {
    Debug.Log("OnEnable Active");
    if (GameController.Instance == null)
    return;
   }

   private void OnDisable()
   {
    if (GameController.Instance == null)
    return;
   }

   void HandlePlayerFlap()
   {
    Debug.Log("handle player flap method");
    audioSource.PlayOneShot(backgroundmorningSoundSound);
   }
    void HandlePointScored()
    {
     audioSource.PlayOneShot(scoreSound);
    }
    void HandlePlayerHit()
    {
     audioSource.PlayOneShot(hitSound);
    }
}


