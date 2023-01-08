using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
  [SerializeField] private Door doorToUnlock;
  [SerializeField] private float keyRotationSpeed = 100f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(Vector3.one * keyRotationSpeed * Time.deltaTime);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      doorToUnlock.UnlockDoor();
      Destroy(gameObject);
    }
  }

  // Callback to draw gizmos that are pickable and always drawn.
  void OnDrawGizmos()
  {
    if (doorToUnlock != null)
    {
      Gizmos.color = Color.green;
      Gizmos.DrawLine(transform.position, doorToUnlock.transform.position);
    }
    else
    {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.35f);
    }
  }
}
