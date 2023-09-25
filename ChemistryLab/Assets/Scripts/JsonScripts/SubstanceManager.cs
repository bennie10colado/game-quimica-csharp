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

    public List<SubstanceSolvent> solventsList = new List<SubstanceSolvent>();
    public List<SubstanceCompound> compoundsList = new List<SubstanceCompound>();
    public List<SubstanceSolution> solutionsList = new List<SubstanceSolution>();

    void Awake()
    {
        LoadSolvents();
        LoadCompounds();
        LoadSolubility();
    }

    void LoadSolvents()
    {
        string jsonTextSol = File.ReadAllText(solventsJsonFilePath);
        solventsCollection = JsonUtility.FromJson<SolventsCollection>(jsonTextSol);
        
        foreach (var solventData in solventsCollection.solvents)
        {
            SubstanceSolvent solvent = ConvertDataToSubstanceSolvent(solventData);
            solventsList.Add(solvent);
        }
        
        //print de cada elemento da lista
        foreach (var solvent in solventsList)
        {
            if (!solvent) //por algum motivo um objeto completo é tratado como nulo nessa verificacao
            {
                //Debug.Log("Solvente: " + solvent.GetCompoundName() + ", Densidade: " + solvent.GetDensity());
            }
        }

    }

    void LoadCompounds()
    {
        string jsonTextComp = File.ReadAllText(compoundsJsonFilePath);
        compoundsCollection = JsonUtility.FromJson<CompoundsCollection>(jsonTextComp);
        
        foreach (var compoundData in compoundsCollection.compounds)
        {
            SubstanceCompound compound = ConvertDataToSubstanceCompound(compoundData);
            compoundsList.Add(compound);
        }

        foreach (var compound in compoundsList)
        {
            if (!compound)
            {
                //Debug.Log("Composto Químico: " + compound.GetCompoundName() + " " + "Id: " + compound.GetId() + ", Densidade: " + compound.GetDensity() + " " + "Cor: " + compound.GetColor() + " " + "Grupo: " + compound.GetGroupName() + " " + "Estado físico: " + compound.GetState() + " ");
            }
        }
    }

    void LoadSolubility()
    {
        string jsonTextSolub = File.ReadAllText(solutionsJsonFilePath);
        solutionsCollection = JsonUtility.FromJson<SolutionsCollection>(jsonTextSolub);
        
        foreach (var solubilityData in solutionsCollection.solutions)
        {
            SubstanceSolution solution = ConvertDataToSubstanceSolution(solubilityData);
            solutionsList.Add(solution);
        }

        foreach (var sol in solutionsList)
        {
            //Debug.Log("Solução: " + sol.GetSolutionName() + " " + "Id: " + sol.GetId() + ", Densidade: " + sol.GetDensity() + ", Cor: " + sol.GetColor() + ", Estado físico: " + sol.GetState() + ", Nome do solvente que está presente na reação: " + sol.GetSolvent().GetCompoundName() + ", Nome do composto quimico organico que está presente na reação: " + sol.GetCompound().GetCompoundName() + ", E o resultado da sua solução é: " + sol.GetSolubilityResult());
        }
    }

    public SubstanceSolvent ConvertDataToSubstanceSolvent(SolventData solventData)
    {
        Color color = ConvertToColor(solventData.color);
        PhysicalState state = ConvertToPhysicalState(solventData.state);
        return new SubstanceSolvent(solventData.id, solventData.compoundName, color, state, solventData.density);
    }

    public SubstanceCompound ConvertDataToSubstanceCompound(CompoundData compoundData)
    {        
        Color color = ConvertToColor(compoundData.color);
        PhysicalState state = ConvertToPhysicalState(compoundData.state);
        GroupName groupName = ConvertToGroupName(compoundData.groupName);

        return new SubstanceCompound(compoundData.id, compoundData.compoundName, color, state, compoundData.density, groupName);
    }

    public SubstanceSolution ConvertDataToSubstanceSolution(SolubilityData solubilityData)
    {
        SubstanceSolvent solvent = FindSolventById(solubilityData.solventId);
        SubstanceCompound compound = FindCompoundById(solubilityData.compoundId);
        Color color = ConvertToColor(solubilityData.color);
        PhysicalState state = ConvertToPhysicalState(solubilityData.state);
        SolubilityResults solubilityResult = ConvertToSolubilityResults(solubilityData.solubilityResult);

        return new SubstanceSolution(solubilityData.id, solvent, compound, solubilityData.solutionName, color, state, solubilityData.density, solubilityResult);
    }
    
    public Color ConvertToColor(string colorStr)
    {
        //Debug.Log("Converting color string: " + colorStr);
        if (ColorUtility.TryParseHtmlString(colorStr, out Color color))
        {
            //Debug.Log("Converted to: " + color.ToString());
            return color;
        }
        Debug.LogWarning("Failed to convert color string. Defaulting to white.");
        return Color.white;
    }

    public PhysicalState ConvertToPhysicalState(string stateStr)
    {
        if (Enum.TryParse(typeof(PhysicalState), stateStr, true, out object state))
        {
            return (PhysicalState)state;
        }
        throw new ArgumentException("Invalid PhysicalState string: " + stateStr);
    }

    public GroupName ConvertToGroupName(string groupNameStr)
    {
        if (Enum.TryParse(typeof(GroupName), groupNameStr, true, out object groupName))
        {
            return (GroupName)groupName;
        }
        throw new ArgumentException("Invalid GroupName string: " + groupNameStr);
    }

    public SolubilityResults ConvertToSolubilityResults(string solubilityResultsStr)
    {
        if (Enum.TryParse(typeof(SolubilityResults), solubilityResultsStr, true, out object solubilityResult))
        {
            return (SolubilityResults)solubilityResult;
        }
        throw new ArgumentException("Invalid SolubilityResults string: " + solubilityResultsStr);
    }

    public SubstanceSolvent FindSolventByName(string name)
    {
        return solventsList.Find(solvent => solvent.GetCompoundName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public SubstanceSolvent FindSolventById(int id)
    {
        foreach (var solvent in solventsList)
        {
            if (solvent.GetId() == id)
            {
                return solvent;
            }
        }
        return null;
    }

    public SubstanceCompound FindCompoundByName(string name)
    {
        return compoundsList.Find(compound => compound.GetCompoundName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public SubstanceCompound FindCompoundById(int id)
    {
        return compoundsList.Find(compound => compound.GetId() == id);
    }

    public SubstanceSolution FindSolutionByName(string name)
    {
        return solutionsList.Find(solution => solution.GetSolutionName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public SubstanceSolution FindSolutionById(int id)
    {
        return solutionsList.Find(solution => solution.GetId() == id);
    }
    
}
