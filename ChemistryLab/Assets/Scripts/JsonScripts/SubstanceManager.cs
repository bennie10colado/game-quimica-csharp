using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

[System.Serializable]
public class CompoundsCollection
{
    public List<CompoundData> compounds;
}

[System.Serializable]
public class SolventsCollection
{
    public List<SolventData> solvents;
}

[System.Serializable]
public class SolutionsCollection
{
    public List<SolubilityData> solutions;
}

public class SubstanceManager : MonoBehaviour
{
    public string solutionsJsonFilePath = "Assets/Resources/SolubilityData.json";
    public string solventsJsonFilePath = "Assets/Resources/SolventsData.json";
    public string compoundsJsonFilePath = "Assets/Resources/CompoundsData.json";

    public SolventsCollection solventsCollection;
    public CompoundsCollection compoundsCollection;
    public SolutionsCollection solutionsCollection;

    public List<SolventData> solventsList = new List<SolventData>();
    public List<CompoundData> compoundsList = new List<CompoundData>();
    public List<SolubilityData> solutionsList = new List<SolubilityData>();

    void Start()
    {
        LoadSolvents();
        LoadCompounds();
        LoadSolubility();
    }

    void LoadSolvents()
    {
        string jsonTextSol = File.ReadAllText(solventsJsonFilePath);
        solventsCollection = JsonUtility.FromJson<SolventsCollection>(jsonTextSol);

        foreach (var solvent in solventsCollection.solvents)
        {
            solventsList.Add(solvent);
        }

        foreach (var solvent in solventsList)
        {
            if (solvent != null)
            {
                //Debug.Log("Solvente: " + solvent.compoundName + ", Densidade: " + solvent.density);
            }
            else
            {
                //Debug.Log("Um solvente nulo foi encontrado na lista");
            }
        }
    }

    void LoadCompounds()
    {
        string jsonTextComp = File.ReadAllText(compoundsJsonFilePath);
        compoundsCollection = JsonUtility.FromJson<CompoundsCollection>(jsonTextComp);

        foreach (var compound in compoundsCollection.compounds)
        {
            compoundsList.Add(compound);
        }

        foreach (var compound in compoundsList)
        {
            if (compound != null)
            {
                //Debug.Log("Composto: " + compound.compoundName + ", Densidade: " + compound.density);
            }
            else
            {
                //Debug.Log("Um composto nulo foi encontrado na lista");
            }
        }

    }

    void LoadSolubility()
    {
        string jsonTextSolub = File.ReadAllText(solutionsJsonFilePath);
        //Debug.Log(jsonTextSolub);
        solutionsCollection = JsonUtility.FromJson<SolutionsCollection>(jsonTextSolub);

        foreach (var solution in solutionsCollection.solutions)
        {
            solutionsList.Add(solution);
        }

        foreach (var solution in solutionsList)
        {
            if (solution != null)
            {
                //Debug.Log("Solução: " + solution.solutionName + ", Densidade: " + solution.density);
            }
            else
            {
                //Debug.Log("Uma solucao nulo foi encontrada na lista");
            }
        }
    }



}
