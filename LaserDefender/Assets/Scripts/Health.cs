using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] bool isPlayer;
  [SerializeField] int health = 50;
  [SerializeField] int score = 50;
  [SerializeField] ParticleSystem hitFX;

  [SerializeField] bool applyCameraShake;
  CameraShake cameraShake;

  AudioPlayer audioPlayer;
  ScoreKeeper scoreKeeper;
  SceneController sceneController;

  public int GetHealth()
  {
    return health;
  }

  void Awake()
  {
    cameraShake = Camera.main.GetComponent<CameraShake>();
    audioPlayer = FindObjectOfType<AudioPlayer>();
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
    sceneController = FindObjectOfType<SceneController>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();

    if (damageDealer != null)
    {
      TakeDamage(damageDealer.GetDamage());
      PlayHitFX();
      ShakeCamera();
      audioPlayer.PlayHittingClip();
      damageDealer.Hit();
    }
  }

  void TakeDamage(int damage)
  {
    health -= damage;

    if (health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    if (!isPlayer)
    {
      scoreKeeper.ModifyScore(score);
    }
    else
    {
      audioPlayer.PlayDyingClip();
      sceneController.LoadGameOver();
    }
    Destroy(gameObject);
  }

  void PlayHitFX()
  {
    if (hitFX != null)
    {
      ParticleSystem instance = Instantiate(hitFX, transform.position, Quaternion.identity);
      Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
  }

  void ShakeCamera()
  {
    if (applyCameraShake && cameraShake != null)
    {
      cameraShake.Play();
    }
  }
}
