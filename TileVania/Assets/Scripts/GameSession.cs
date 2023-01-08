using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField] int playerHeart = 3;
  [SerializeField] int playerScore = 0;
  [SerializeField] float respawnDelay = 2f;
  [SerializeField] TextMeshProUGUI heartText;
  [SerializeField] TextMeshProUGUI scoreText;

  void Awake()
  {
    int totalGameSession = FindObjectsOfType<GameSession>().Length;

    if (totalGameSession > 1)
      Destroy(gameObject);
    else
      DontDestroyOnLoad(gameObject);
  }

  void Start()
  {
    heartText.text = playerHeart.ToString();
    scoreText.text = playerScore.ToString();
  }

  public void ProcessPlayerDeath()
  {
    if (playerHeart > 1)
      StartCoroutine(TakeHeart());
    else
      StartCoroutine(ResetGameSession());

  }

  public void ProcessPlayerScore(int scorePoint)
  {
    playerScore += scorePoint;
    scoreText.text = playerScore.ToString();
  }

  IEnumerator TakeHeart()
  {
    yield return new WaitForSecondsRealtime(respawnDelay);

    playerHeart--;
    heartText.text = playerHeart.ToString();

    int curScene = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(curScene);
  }

  IEnumerator ResetGameSession()
  {
    yield return new WaitForSecondsRealtime(respawnDelay);

    FindObjectOfType<SceneSession>().ResetSession();
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
}
