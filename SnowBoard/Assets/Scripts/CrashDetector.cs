using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float reloadDelay = 2f;
  [SerializeField] ParticleSystem crashParticle;

  bool isCrash = false;


  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ground") && !isCrash)
    {
      isCrash = true;
      crashParticle.Play();
      FindObjectOfType<PlayerController>().DisableControl();
      Invoke("ReloadScene", reloadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
