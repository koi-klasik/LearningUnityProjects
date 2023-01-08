using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] private float steerSpeed = 250f;
  [SerializeField] private float moveSpeed = 15f;
  [SerializeField] private float slowSpeed = 15f;
  [SerializeField] private float boostSpeed = 25f;

  private float hozInput;
  private float verInput;

  void Update()
  {
    verInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    hozInput = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

    moveCar(verInput, hozInput);
  }

  void moveCar(float v, float h)
  {
    transform.Translate(0, v, 0);

    if (v > 0)
      transform.Rotate(0, 0, -h);
    else if (v < 0)
      transform.Rotate(0, 0, h);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    moveSpeed = slowSpeed;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Buff"))
    {
      moveSpeed = boostSpeed;
      Destroy(other.gameObject);
    }
  }
}
