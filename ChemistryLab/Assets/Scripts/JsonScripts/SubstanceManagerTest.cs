using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceManagerTest : MonoBehaviour
{
    public SubstanceManager substanceManager;

    void Start()
    {
        if (substanceManager == null)
        {
            Debug.LogError("SubstanceManager não está definido! Por favor, atribua no Inspector.");
            return;
        }

        //TestAddCompound();
    }

    void TestAddCompound()
    {
        CompoundData newCompound = new CompoundData
        {
            id = 111111,
            compoundName = "Teste",
            color = "#111111",
            state = "Liquid",
            groupName = "S1",
            density = 1.0f
        };

        substanceManager.AddCompound(newCompound);
        Debug.Log("Composto adicionado com sucesso!");
    }
}

