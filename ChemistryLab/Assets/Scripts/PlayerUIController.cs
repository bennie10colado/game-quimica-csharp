using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameController gameController;
    public Text questionText;
    public Text feedbackText;
    public Button[] answerButtons;

    private void Start()
    {
        //gameController.StartGame();
    }

    public void SelectAnswer(int answerIndex)
    {
        //bool isCorrect = gameController.CheckAnswer(answerIndex);
        //feedbackText.text = isCorrect ? "Resposta correta!" : "Resposta incorreta!";
        //UpdateQuestion();
    }

    private void UpdateQuestion()
    {

    }
}