using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    private int id;
    private string description;
    private string feedback;
    private SubstanceCompound answer;
    public List<SubstanceCompound> choices;

    public Question(int id, string description, string feedback, SubstanceCompound answer)
    {
        this.id = id;
        this.description = description;
        this.feedback = feedback;
        this.answer = answer;
    }

    public void UpdateQuestion(Question updatedQuestion)
    {
        this.description = updatedQuestion.description;
        this.feedback = updatedQuestion.feedback;
        this.answer = updatedQuestion.answer;
    }

    public int GetId()
    {
        return id;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetFeedback()
    {
        return feedback;
    }

    public SubstanceCompound GetAnswer()
    {
        return answer;
    }
}
