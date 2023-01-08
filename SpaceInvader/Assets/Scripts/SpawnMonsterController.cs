using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterController : MonoBehaviour
{
  public GameObject monster1;
  public GameObject monster2;
  public float interval = 3.0f;

  void Start()
  {
    InvokeRepeating("SpawnMonster", interval, interval);
  }

  private void SpawnMonster()
  {
    float rand = Random.value;

    if (rand < 0.2)
    {
      Instantiate(monster2, transform.position, Quaternion.identity);
    }
    else if (rand < 0.4)
    {
      Instantiate(monster1, transform.position, Quaternion.identity);
    }
  }
}
