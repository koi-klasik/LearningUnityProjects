using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
  [SerializeField] float nextLevelDelay = 1f;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
      StartCoroutine(LoadNextLevel());
  }

  IEnumerator LoadNextLevel()
  {
    yield return new WaitForSecondsRealtime(nextLevelDelay);
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    int nextScene = currentScene + 1;

    if (nextScene == SceneManager.sceneCountInBuildSettings)
      nextScene = 0;

    FindObjectOfType<SceneSession>().ResetSession();
    SceneManager.LoadScene(nextScene);
  }
}
