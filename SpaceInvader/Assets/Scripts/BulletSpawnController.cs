using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnController : MonoBehaviour
{
  public GameObject bullet;
  public float interval = 1.0f;

  void Start()
  {
    InvokeRepeating("Shoot", interval, interval);
  }

  private void Shoot()
  {
    GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);
  }
}
