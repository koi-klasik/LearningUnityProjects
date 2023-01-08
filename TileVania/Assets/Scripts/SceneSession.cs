using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSession : MonoBehaviour
{
  void Awake()
  {
    int totalSceneSession = FindObjectsOfType<SceneSession>().Length;

    if (totalSceneSession > 1)
      Destroy(gameObject);
    else
      DontDestroyOnLoad(gameObject);
  }

  public void ResetSession()
  {
    Destroy(gameObject);
  }
}