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
            Debug.LogError("SubstanceManager não está definido. Atribuir no Inspector!");
            return;
        }

        // Testes de Adição
        //TestAddCompound();
        //TestAddSolvent();
        //TestAddSolubility();

        // Testes de Busca
        //TestFindSolventByName();
        //TestFindSolventById();
        //TestFindCompoundByName();
        //TestFindCompoundById();
        //TestFindSolutionByName();
        //TestFindSolutionById();

        // Testes de Impressão
        //TestPrintAllCompounds();
        //TestPrintAllSolvents();
        //TestPrintAllSolutions();

        // Testes de Atualização
        //TestUpdateCompound();
        //TestUpdateSolvent();
        //TestUpdateSolution();

        TestDeleteCompound();
        //TestDeleteSolvent();
        //TestDeleteSolution();
    }

    void TestAddCompound()
    {
        CompoundData newCompound = new CompoundData
        {
            id = 111111,
            compoundName = "Composto Teste 1",
            color = "#111111",
            state = "Liquid",
            groupName = "S1",
            density = 1.0f
        };

        substanceManager.AddCompound(newCompound);
    }

    void TestAddSolvent()
    {
        SolventData newSolvent = new SolventData
        {
            id = 44444,
            compoundName = "Álcool Etílico teste 1",
            color = "#C2C2C2",
            state = "Liquid",
            density = 0.789f
        };

        substanceManager.AddSolvent(newSolvent);
    }

    void TestAddSolubility()
    {
        SolubilityData newSolubility = new SolubilityData
        {
            id = 55555,
            solventId = 7,
            compoundId = 10,
            solutionName = "Solução Teste 1",
            color = "#FFFFFF",
            state = "Liquid",
            density = 1.0f,
            solubilityResult = "Soluble"
        };

        substanceManager.AddSolubility(newSolubility);
    }

    void TestFindSolventByName()
    {
        string solventName = "Éter dietílico";
        SubstanceSolvent foundSolvent = substanceManager.FindSolventByName(solventName);

        if (foundSolvent.GetCompoundName() != null)
            Debug.Log("Solvente encontrado: " + foundSolvent.GetCompoundName());
        else
            Debug.LogError("Solvente não encontrado: " + solventName);
    }

    void TestFindSolventById()
    {
        int solventId = 1;
        SubstanceSolvent foundSolvent = substanceManager.FindSolventById(solventId);

        if (foundSolvent.GetCompoundName() != null)
            Debug.Log("Solvente encontrado: " + foundSolvent.GetCompoundName());
        else
            Debug.LogError("Solvente não encontrado com ID: " + solventId);
    }

    void TestFindCompoundByName()
    {
        string compoundName = "Cicloexanona";
        SubstanceCompound foundCompound = substanceManager.FindCompoundByName(compoundName);

        if (foundCompound.GetCompoundName() != null)
            Debug.Log("Composto encontrado: " + foundCompound.GetCompoundName());
        else
            Debug.LogError("Composto não encontrado: " + compoundName);
    }

    void TestFindCompoundById()
    {
        int compoundId = 2;
        SubstanceCompound foundCompound = substanceManager.FindCompoundById(compoundId);

        if (foundCompound.GetCompoundName() != null)
            Debug.Log("Composto encontrado: " + foundCompound.GetCompoundName());
        else
            Debug.LogError("Composto não encontrado com ID: " + compoundId);
    }

    void TestFindSolutionByName()
    {
        string solutionName = "Solução de Etanoato de etila em Água";
        SubstanceSolution foundSolution = substanceManager.FindSolutionByName(solutionName);

        if (foundSolution.GetSolutionName() != null)
            Debug.Log("Solução encontrada: " + foundSolution.GetSolutionName());
        else
            Debug.LogError("Solução não encontrada: " + solutionName);
    }

    void TestFindSolutionById()
    {
        int solutionId = 3;
        SubstanceSolution foundSolution = substanceManager.FindSolutionById(solutionId);

        if (foundSolution.GetSolutionName() != null)
            Debug.Log("Solução encontrada: " + foundSolution.GetSolutionName());
        else
            Debug.LogError("Solução não encontrada com ID: " + solutionId);
    }

    void TestPrintAllCompounds()
    {
        substanceManager.PrintAllCompounds();
    }

    void TestPrintAllSolvents()
    {
        substanceManager.PrintAllSolvents();
    }

    void TestPrintAllSolutions()
    {
        substanceManager.PrintAllSolutions();
    }

    void TestUpdateCompound()
    {
        Debug.Log("Atualizando Composto...");
        substanceManager.UpdateCompound(111111, "Composto Teste Atualizado", "#222222", "Solid", 2.0f, "S2");
    }

    void TestUpdateSolvent()
    {
        Debug.Log("Atualizando Solvente...");
        substanceManager.UpdateSolvent(44444, "Água Oxigenada Atualizada", "#FFFFFF", "Liquid", 1.0f);
    }

    void TestUpdateSolution()
    {
        Debug.Log("Atualizando Solução...");
        substanceManager.UpdateSolution(55555, 444444, 111111, "Solução Atualizada", "#AAAAAA", "Liquid", 0.5f, "InsolubleAbove");
    }

    void TestDeleteCompound()
    {
        int compoundId = 111111;
        substanceManager.DeleteCompoundById(compoundId);
    }

    void TestDeleteSolvent()
    {
        int solventId = 44444;
        substanceManager.DeleteSolventById(solventId);
    }

    void TestDeleteSolution()
    {
        int solutionId = 55555;
        substanceManager.DeleteSolutionById(solutionId);
    }

}


