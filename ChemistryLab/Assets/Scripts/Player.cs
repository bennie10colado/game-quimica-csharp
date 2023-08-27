using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string playerName;
    private int score;

    public Player(string playerName) {
        this.playerName = playerName;
        score = 0;
    }

    //public void InteractWithObject(GameObject obj) {
        // possivel mudança na interação com objetos?
    //}

    //public ChemicalCompound Mix(ChemicalCompound substance1, ChemicalCompound substance2) {
        // retorna o resultado da mistura, porém qual deve ser o tipo dos parametros?
    //}

    public bool AnswerQuestion(Question question, SubstanceCompound answer) {
        if (question.GetAnswer() == answer) {
            UpdateScore(10);
            Debug.LogWarning("Resposta Correta!");
            return true;
        } else
        {
            Debug.LogWarning("Resposta Incorreta!");
            return false;
        }
    }

    public string GetPlayerName() {
        return playerName;
    }

    public int GetScore() {
        return score;   
    }

    public void UpdateScore(int points) {
        score += points;
    }
}
