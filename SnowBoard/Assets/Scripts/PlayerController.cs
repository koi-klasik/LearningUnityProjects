using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] ParticleSystem boardParticle;
  [SerializeField] SurfaceEffector2D se;
  [SerializeField] float torqueAmount = 10f;
  [SerializeField] float normalSpeed = 15f;
  [SerializeField] float boostSpeed = 30f;

  bool canMove = true;

  Rigidbody2D rb;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    se = FindObjectOfType<SurfaceEffector2D>();
  }

  void Update()
  {
    if (canMove)
    {
      RotateControl();
      RespondToBoost();
    }
  }

  public void DisableControl()
  {
    canMove = false;
  }

  void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      se.speed = boostSpeed;
    }
    else
    {
      se.speed = normalSpeed;
    }
  }

  private void RotateControl()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb.AddTorque(torqueAmount);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      rb.AddTorque(-torqueAmount);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Ground"))
    {
      boardParticle.Play();
    }
  }

  void OnCollisionExit2D(Collision2D other)
  {
    boardParticle.Stop();
  }
}
