using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMonsterBulletController : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Monster" || other.gameObject.tag == "Bullet")
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
