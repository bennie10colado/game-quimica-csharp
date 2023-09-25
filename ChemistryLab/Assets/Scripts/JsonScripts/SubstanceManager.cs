using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

[System.Serializable]
public class ChemicalsCollection
{
    public List<ChemicalCompound> chemicals;
}

[System.Serializable]
public class SolventsCollection
{
    public List<Solvent> solvents;
}

[System.Serializable]
public class SolutionsCollection
{
    public List<Solution> solutions;
}

public class SubstanceManager : MonoBehaviour
{
    public string solutionsJsonFilePath = "Assets/Resources/SolubilityData.json";
    public string solventsJsonFilePath = "Assets/Resources/SolventsData.json";
    public string compoundsJsonFilePath = "Assets/Resources/CompoundsData.json";
    


    void Start()
    {
        LoadSolvents();
        LoadCompounds();
        LoadSolubility();
        
        PrintCompoundList();
    }
    void LoadSolvents()
    {

    }    
    void LoadCompounds()
    {

    }

    void LoadChemicalData()
    {
        
    }

    void PrintCompoundList()
    {
        foreach (SubstanceCompound compound in substanceCompounds)
        {
            Debug.Log("Compound Name: " + compound.GetCompoundName());
            Debug.Log("Physical State: " + compound.GetState());
            Debug.Log("Density: " + compound.GetDensity());
            Debug.Log("Compound Color: " + compound.GetColor());
            Debug.Log("Compound Group: " + compound.GetGroupName());

            foreach (var entry in compound.GetSolubilityTable())
            {
                Debug.Log("Solvent: " + entry.Key + ", Solubility: " + entry.Value);
            }

            Debug.Log("COMPOSTO QUÍMICO FINALIZADO \n");
        }
    }
}
