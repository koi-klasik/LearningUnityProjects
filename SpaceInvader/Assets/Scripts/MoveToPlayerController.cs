using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerController : MonoBehaviour
{
  public float speed = 1.0f;

  void Start()
  {
    GameObject gameObject = GameObject.FindWithTag("Player");

    if (gameObject)
    {
      Vector2 playerPos = (gameObject.transform.position - transform.position).normalized;
      GetComponent<Rigidbody2D>().velocity = playerPos * speed;
    }
  }

}
