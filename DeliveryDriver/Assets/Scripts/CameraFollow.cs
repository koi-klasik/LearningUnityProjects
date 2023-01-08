using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private GameObject car;
  // Update is called once per frame
  void LateUpdate()
  {
    transform.position = car.transform.position + new Vector3(0, 0, -10);
  }
}
