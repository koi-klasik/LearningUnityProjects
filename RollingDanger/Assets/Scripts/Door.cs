using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] private float unlockingSpeed = 2f;
  [SerializeField] private float unlockingTime = 3f;
  [SerializeField] private bool isDoorUnlocked = false;

  public void UnlockDoor()
  {
    isDoorUnlocked = true;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (isDoorUnlocked)
    {
      unlockingTime -= Time.deltaTime; transform.Translate(Vector3.down * unlockingSpeed * Time.deltaTime);

      if (unlockingTime <= 0)
      {
        gameObject.SetActive(false);
      }
    }
  }
}
