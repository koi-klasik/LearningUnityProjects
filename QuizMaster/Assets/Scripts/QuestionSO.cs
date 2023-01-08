using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionSO : ScriptableObject
{
  [TextArea(2, 10)][SerializeField] string question = "Enter new Question here!";
  [SerializeField] string[] answer = new string[4];
  [SerializeField] int correctAnswerIndex;

  public string GetQuestion()
  {
    return question;
  }

  public string GetAnswer(int index)
  {
    return answer[index];
  }

  public int GetCorrectAnswerIndex()
  {
    return correctAnswerIndex;
  }

}
