using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  int currentScore = 0;
  static ScoreKeeper instance;

  void Awake()
  {
    ManageSingleton();
  }

  void ManageSingleton()
  {
    if (instance != null)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  public int GetCurrentScore()
  {
    return currentScore;
  }

  public void ModifyScore(int score)
  {
    currentScore += score;
    Mathf.Clamp(currentScore, 0, int.MaxValue);
  }

  public void ResetScore()
  {
    currentScore = 0;
  }
}
