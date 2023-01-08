using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] float bulletSpeed = 10f;
  [SerializeField] int killPoint = 50;
  float bulletDir;

  // ref
  Rigidbody2D myRigidbody;
  PlayerMovement player;

  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();
    player = FindObjectOfType<PlayerMovement>();

    bulletDir = player.transform.localScale.x;
    transform.localScale = new Vector2(-(Mathf.Sign(bulletDir)) * transform.localScale.x, transform.localScale.y);
  }

  void Update()
  {
    myRigidbody.velocity = new Vector2(bulletSpeed * bulletDir, 0f);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Enemy"))
    {
      FindObjectOfType<GameSession>().ProcessPlayerScore(killPoint);
      other.gameObject.SetActive(false);
      Destroy(other.gameObject);
    }
    Destroy(gameObject);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Destroy(gameObject);
  }
}
