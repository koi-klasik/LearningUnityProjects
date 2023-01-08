using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{
  [SerializeField] Color32 isCollectedColor = new Color32(1, 1, 1, 1);
  [SerializeField] Color32 isNotCollectedColor = new Color32(1, 1, 1, 1);

  [SerializeField] float destroyDelay = 0.1f;
  bool isCollected = false;

  SpriteRenderer carSpriteRenderer;

  void Start()
  {
    carSpriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Package") && !isCollected)
    {
      isCollected = true;
      carSpriteRenderer.color = isCollectedColor;
      Destroy(other.gameObject, destroyDelay);
    }

    if (other.CompareTag("Customer"))
    {
      if (isCollected)
      {
        carSpriteRenderer.color = isNotCollectedColor;
        isCollected = false;
      }
    }
  }

}
