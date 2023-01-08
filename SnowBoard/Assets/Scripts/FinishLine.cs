using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float reloadDelay = 2f;
  [SerializeField] ParticleSystem finishParticle;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      finishParticle.Play();
      Invoke("ReloadScene", reloadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
