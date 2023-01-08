using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
  [SerializeField] AudioClip coinSfx;
  [SerializeField] int coinPoint = 100;

  bool wasCollected = false;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !wasCollected)
    {
      wasCollected = true;
      FindObjectOfType<GameSession>().ProcessPlayerScore(coinPoint);
      AudioSource.PlayClipAtPoint(coinSfx, Camera.main.transform.position);
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
  }
}
