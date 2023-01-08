using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver;

    public GameObject gameOverUI;

    void Start()
    {
        IsGameOver = false;
    }

    void Update()
    {
        if (IsGameOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        IsGameOver = true;
        gameOverUI.SetActive(true);
    }
}
