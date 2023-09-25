using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private List<Question> questionList;
    private Player player;
    
    void Start()
    {
        questionList = new List<Question>();
        player = new Player("ben");
        Color incolor = new Color(0, 0, 0, 0);

        InitializeSolubilities();
        //carregar questoes de um arquivo no futuro? é possível
        InitializeQuestions();

    }

    void InitializeSolubilities()
    {
    }
    
    void InitializeQuestions()
    {
        
    }

    void StartGame()
    {
        //configuracoes para o inicio do jogo
        Question currentQuestion = GenerateQuestion();
        Debug.Log("Pergunta: " + currentQuestion.GetDescription());
    }

    Question GenerateQuestion()
    {
        return questionList[Random.Range(0, questionList.Count)];
    }

    void AddQuestion(Question question)
    {
        questionList.Add(question);
    }

    List<Question> ListQuestions()
    {
        return questionList;
    }

    void UpdateQuestion(int questionId, Question updatedQuestion)
    {
        Question questionToUpdate = questionList.Find(q => q.GetId() == questionId);
        if (questionToUpdate != null)
        {
            questionToUpdate.UpdateQuestion(updatedQuestion);
        }
    }

    void RemoveQuestion(int questionId)
    {
        Question questionToRemove = questionList.Find(q => q.GetId() == questionId);
        if (questionToRemove != null)
        {
            questionList.Remove(questionToRemove);
        }
    }

    bool CheckAnswer(SubstanceCompound answer)
    {
        Question currentQuestion = GenerateQuestion();
        return currentQuestion.GetAnswer() == answer;
    }

    SubstanceCompound MixSubstances(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        //Reaction reaction = new Reaction(compound, solvent);
        //return reaction.PerformReaction();
		return null;
    }

    void UpdateScore(int score)
    {
        player.UpdateScore(score);
    }

}
