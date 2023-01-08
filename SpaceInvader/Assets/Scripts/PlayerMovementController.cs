using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
  public float speed = 10.0f;
  private Rigidbody2D player;
  private Animator animator;

  void Start()
  {
    player = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector2 dir = new Vector2(h, v);

    player.velocity = dir.normalized * speed;

    animator.SetBool("isFlyingLeft", h < 0);
    animator.SetBool("isFlyingRight", h > 0);
    animator.SetBool("isFlyingUp", v > 0);
    animator.SetBool("isFlyingDown", v < 0);
  }
}
