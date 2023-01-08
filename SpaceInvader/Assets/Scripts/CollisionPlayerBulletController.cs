using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerBulletController : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
    {
      Physics2D.IgnoreCollision(other.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    else
    {
      Destroy(gameObject);
      if (other.gameObject.tag != "Wall")
      {
        Destroy(other.gameObject);
      }
    }
  }
}
