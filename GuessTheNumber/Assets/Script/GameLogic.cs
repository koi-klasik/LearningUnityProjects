using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
  public InputField userInput;
  public Text message, chanceLeft;
  public Button gameButton;
  private int randomNum;
  private bool isGameWon = false;
  private int chance;

  public int minValue, maxValue;

  // Start is called before the first frame update
  void Start()
  {
    ResetGame();
    message.text = "Guess a Number between " + minValue + " and " + maxValue + "!";
  }

  void Update()
  {
    chanceLeft.text = "Chance: " + chance.ToString();

    if (chance == 0)
    {
      ResetGame();
    }
  }
  public void OnButtonClick()
  {
    string userInputValue = userInput.text;
    if (userInputValue != "")
    {
      int answer = int.Parse(userInputValue);
      if (answer == randomNum)
      {
        message.text = "Correct!";

        isGameWon = true;

        ResetGame();
      }
      else if (answer > randomNum)
      {
        message.text = "Try Lower!";
        chance--;
      }
      else if (answer < randomNum)
      {
        message.text = "Try Higher!";
        chance--;
      }
    }
    else
    {
      message.text = "Input your Answer!";
    }
  }

  private int GetRandomNumber(int min, int max)
  {
    return Random.Range(min, max);
  }

  private void ResetGame()
  {
    minValue = 0;
    maxValue = 20;
    chance = 5;
    randomNum = GetRandomNumber(minValue, maxValue + 1);
    userInput.text = "";
    if (isGameWon)
    {
      message.text = "You Won! Guess a Number between " + minValue + " and " + maxValue + "!";
    }
    else
    {
      message.text = "You Lose! Guess a Number between " + minValue + " and " + maxValue + "!";
    }
    isGameWon = false;
  }
}
