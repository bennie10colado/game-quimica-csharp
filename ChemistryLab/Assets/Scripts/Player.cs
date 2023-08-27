using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string name;
    private int score;

    public Player(string playerName) {
        name = playerName;
        score = 0;
    }

    public void InteractWithObject(GameObject obj) {
        // possivel mudança na interação com objetos?
    }

    //public ChemicalCompound Mix(ChemicalCompound substance1, ChemicalCompound substance2) {
        // retorna o resultado da mistura, porém qual deve ser o tipo dos parametros?
    //}

    public bool AnswerQuestion(Question question, SubstanceCompound answer) {
        // deve retornar verdadeiro se a resposta estiver correta, falso caso contrário
    }

    public string GetName() {
        return name;
    }

    public int GetScore() {
        return score;
    }

    public void UpdateScore(int points) {
        score += points;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
