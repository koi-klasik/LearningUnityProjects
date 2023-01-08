using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
  [SerializeField] private Transform cannonHead;
  [SerializeField] private Transform cannonTip;
  [SerializeField] private float shootingCooldown = 3f;
  [SerializeField] private float laserPower = 1f;

  private GameObject player;
  private LineRenderer cannonLaser;
  private bool isPlayerInRange = false;
  private float timeLeftToShoot = 0f;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    cannonLaser = GetComponent<LineRenderer>();
    cannonLaser.sharedMaterial.color = Color.green;
    cannonLaser.enabled = false;

    timeLeftToShoot = shootingCooldown;
  }

  // Update is called once per frame
  void Update()
  {
    if (isPlayerInRange)
    {
      cannonHead.transform.LookAt(player.transform);

      // set the first point of the laser to be the cannon tip
      cannonLaser.SetPosition(0, cannonTip.transform.position);
      cannonLaser.SetPosition(1, player.transform.position);

      timeLeftToShoot -= Time.deltaTime;
    }

    if (timeLeftToShoot < shootingCooldown * 0.5)
    {
      cannonLaser.sharedMaterial.color = Color.red;
    }

    if (timeLeftToShoot <= 0)
    {
      Vector3 pushBackDir = player.transform.position - cannonTip.transform.position;

      player.GetComponent<Rigidbody>().AddForce(pushBackDir * laserPower, ForceMode.Impulse);

      timeLeftToShoot = shootingCooldown;
      cannonLaser.sharedMaterial.color = Color.green;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      isPlayerInRange = true;
      cannonLaser.enabled = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      isPlayerInRange = false;
      cannonLaser.enabled = false;

      timeLeftToShoot = shootingCooldown;
      cannonLaser.sharedMaterial.color = Color.green;
    }
  }
}
