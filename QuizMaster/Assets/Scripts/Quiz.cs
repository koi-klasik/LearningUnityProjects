using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
  [Header("Question")]
  [SerializeField] TextMeshProUGUI questionText;
  [SerializeField] List<QuestionSO> questionList = new List<QuestionSO>();
  QuestionSO currentQuestion;

  [Header("Answer")]
  [SerializeField] GameObject[] answerButtons;
  int answerIndex;
  bool hasAnsweredEarly = true;

  [Header("Button Colors")]
  [SerializeField] Sprite defaultAnswerSprite;
  [SerializeField] Sprite correctAnswerSprite;

  [Header("Timer")]
  [SerializeField] Image timerImage;
  Timer timer;

  [Header("Scoring")]
  [SerializeField] TextMeshProUGUI scoreText;
  ScoreKeeper scoreKeeper;

  [Header("Progress Bar")]
  [SerializeField] Slider progressBar;

  public bool isComplete;

  void Awake()
  {
    timer = FindObjectOfType<Timer>();
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
    progressBar.maxValue = questionList.Count;
    progressBar.value = 0;
  }

  void Update()
  {
    timerImage.fillAmount = timer.fillFraction;
    if (timer.loadNextQuestion)
    {
      if (progressBar.value == progressBar.maxValue)
      {
        isComplete = true;
        return;
      }

      hasAnsweredEarly = false;
      GetNextQuestion();
      timer.loadNextQuestion = false;
    }
    else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
    {
      DisplayAnswer(-1);
      SetButtonState(false);
    }

  }

  void DisplayQuestion()
  {
    questionText.text = currentQuestion.GetQuestion();

    for (int i = 0; i < answerButtons.Length; i++)
    {
      TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
      buttonText.text = currentQuestion.GetAnswer(i);
    }

    answerIndex = currentQuestion.GetCorrectAnswerIndex();
  }

  void GetNextQuestion()
  {
    if (questionList.Count > 0)
    {
      SetButtonState(true);
      SetDefaultButtonSprite();
      GetRandomQuestion();
      DisplayQuestion();
      progressBar.value++;
      scoreKeeper.IncrementQuestionsSeen();
    }
  }

  void GetRandomQuestion()
  {
    int index = Random.Range(0, questionList.Count);
    currentQuestion = questionList[index];

    if (questionList.Contains(currentQuestion))
    {
      questionList.Remove(currentQuestion);
    }

  }

  void SetButtonState(bool state)
  {
    Button button;
    for (int i = 0; i < answerButtons.Length; i++)
    {
      button = answerButtons[i].GetComponent<Button>();
      button.interactable = state;
    }
  }

  void SetDefaultButtonSprite()
  {
    Image buttonImage;
    for (int i = 0; i < answerButtons.Length; i++)
    {
      buttonImage = answerButtons[i].GetComponent<Image>();
      buttonImage.sprite = defaultAnswerSprite;
    }
  }

  void DisplayAnswer(int index)
  {
    Image buttonImage;
    if (index == currentQuestion.GetCorrectAnswerIndex())
    {
      questionText.text = "Correct!";
      buttonImage = answerButtons[index].GetComponent<Image>();
      buttonImage.sprite = correctAnswerSprite;
      scoreKeeper.IncrementCorrectAnswers();
    }
    else
    {
      questionText.text = "Wrong! The Correct Answer is\n'" + currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex()) + "'";
      buttonImage = answerButtons[currentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>();
      buttonImage.sprite = correctAnswerSprite;
    }
  }

  public void OnAnswerSelected(int index)
  {
    hasAnsweredEarly = true;
    DisplayAnswer(index);
    SetButtonState(false);

    timer.CancelTimer();

    scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
  }

}
