using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  [SerializeField] float sceneLoadDelay = 1.5f;
  ScoreKeeper scoreKeeper;

  void Awake()
  {
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
  }

  public void LoadGame()
  {
    scoreKeeper.ResetScore();
    Load("Game");
  }

  public void LoadMainMenu()
  {
    Load("MainMenu");
  }

  public void LoadGameOver()
  {
    StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
  }

  void Load(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  IEnumerator WaitAndLoad(string sceneName, float delay)
  {
    yield return new WaitForSeconds(delay);
    Load(sceneName);
  }
}
