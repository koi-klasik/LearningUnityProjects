using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
  private Rigidbody rbEnemy;
  private GameObject player;

  [SerializeField] private float speed = 1f;

  private bool isPlayerInRange = false;
  // Start is called before the first frame update
  void Start()
  {
    rbEnemy = GetComponent<Rigidbody>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  // Update is called once per frame
  void Update()
  {

  }

  // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  private void FixedUpdate()
  {
    if (isPlayerInRange)
    {
      Vector3 targetDirection = player.transform.position - transform.position;
      rbEnemy.AddForce(targetDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

      Vector3 newVelocity = rbEnemy.velocity;
      newVelocity.y = 0;

      rbEnemy.velocity = newVelocity;
    }
  }

  // OnTriggerEnter is called when the Collider other enters the trigger.
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
      isPlayerInRange = true;
  }

  // OnTriggerExit is called when the Collider other has stopped touching the trigger.
  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
      isPlayerInRange = false;
  }
}
