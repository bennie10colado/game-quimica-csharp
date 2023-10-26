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
        //SubstanceSolvent solvent = FindSolventById(solubilityData.solventId);
        //SubstanceCompound compound = FindCompoundById(solubilityData.compoundId);
        Color color = ConvertToColor(solubilityData.color);
        PhysicalState state = ConvertToPhysicalState(solubilityData.state);
        SolubilityResults solubilityResult = ConvertToSolubilityResults(solubilityData.solubilityResult);

        return new SubstanceSolution(solubilityData.id, solubilityData.solventId, solubilityData.compoundId, solubilityData.solutionName, color, state, solubilityData.density, solubilityResult);
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

    public void AddCompound(CompoundData newCompoundData)
    {
        foreach (var compound in compoundsList)
        {
            if (compound.GetId() == newCompoundData.id)
            {
                Debug.LogError("Um composto com o mesmo ID já existe!");
                return;
            }
        }
        string jsonTextComp = File.ReadAllText(compoundsJsonFilePath);
        compoundsCollection = JsonUtility.FromJson<CompoundsCollection>(jsonTextComp);

        compoundsCollection.compounds.Add(newCompoundData);
        compoundsList.Add(ConvertDataToSubstanceCompound(newCompoundData));

        SaveCompounds();
        //Debug.Log(newCompoundData.compoundName + "Foi adicionado com sucesso!");

    }

    void SaveCompounds()
    {
        string jsonTextComp = JsonUtility.ToJson(compoundsCollection);
        File.WriteAllText(compoundsJsonFilePath, jsonTextComp);
    }

    public void AddSolvent(SolventData newSolvent)
    {
        foreach (var solvent in solventsList)
        {
            if (solvent.GetId() == newSolvent.id)
            {
                Debug.LogError("Um solvente com o mesmo ID já existe!");
                return;
            }
        }

        solventsCollection.solvents.Add(newSolvent);
        solventsList.Add(ConvertDataToSubstanceSolvent(newSolvent));
        SaveSolvents();
        //Debug.Log(newSolvent.compoundName + "Foi adicionado com sucesso!");
    }

    void SaveSolvents()
    {
        string json = JsonUtility.ToJson(solventsCollection, true);
        File.WriteAllText(solventsJsonFilePath, json);
    }

    public void AddSolubility(SolubilityData newSolubilityData)
    {
        SubstanceSolvent solvent = FindSolventById(newSolubilityData.solventId);
        SubstanceCompound compound = FindCompoundById(newSolubilityData.compoundId);

        if (solvent.GetCompoundName() == null)
        {
            Debug.LogError($"Erro: Não foi possível adicionar a solubilidade porque o solvente com ID {newSolubilityData.solventId} não existe!");
            return;
        }

        if (compound.GetCompoundName() == null)
        {
            Debug.LogError($"Erro: Não foi possível adicionar a solubilidade porque o composto com ID {newSolubilityData.compoundId} não existe!");
            return;
        }

        if (SolubilityIdExists(newSolubilityData.id))
        {
            Debug.LogError($"Erro: O ID de solubilidade {newSolubilityData.id} já está em uso!");
            return;
        }

        if (SolubilityCombinationExists(newSolubilityData.solventId, newSolubilityData.compoundId))
        {
            Debug.LogError($"Erro: Uma Solução de solubilidade para o solvente com ID {newSolubilityData.solventId} e o composto com ID {newSolubilityData.compoundId} já existe no banco de dados!");
            return;
        }

        SubstanceSolution newSolubility = ConvertDataToSubstanceSolution(newSolubilityData);
        solutionsList.Add(newSolubility);
        solutionsCollection.solutions.Add(newSolubilityData);
        SaveSolubilities();
        Debug.Log($"{newSolubilityData.solutionName} foi adicionado com sucesso!");
    }

    bool SolubilityCombinationExists(int solventId, int compoundId)
    {
        foreach (SubstanceSolution solubility in solutionsList)
        {
            if (solubility.GetSolventId() == solventId && solubility.GetCompoundId() == compoundId)
                return true;
        }
        return false;
    }

    bool SolubilityIdExists(int solubilityId)
    {
        foreach (SubstanceSolution solubility in solutionsList)
        {
            if (solubility.GetId() == solubilityId)
                return true;
        }
        return false;
    }

    void SaveSolubilities()
    {
        string json = JsonUtility.ToJson(solutionsCollection, true);
        File.WriteAllText(solutionsJsonFilePath, json);
    }

    public SubstanceSolvent FindSolventByName(string name)
    {
        SubstanceSolvent solvent = solventsList.Find(s => s.GetCompoundName().Equals(name, StringComparison.OrdinalIgnoreCase));
        if (solvent == null)
        {
            Debug.LogError($"Solvente com nome '{name}' não encontrado.");
        }
        return solvent;
    }

    public SubstanceSolvent FindSolventById(int id)
    {
        SubstanceSolvent solvent = solventsList.Find(s => s.GetId() == id);
        if (solvent == null)
        {
            Debug.LogError($"Solvente com ID {id} não encontrado.");
        }
        return solvent;
    }

    public SubstanceCompound FindCompoundByName(string name)
    {
        SubstanceCompound compound = compoundsList.Find(c => c.GetCompoundName().Equals(name, StringComparison.OrdinalIgnoreCase));
        if (compound == null)
        {
            Debug.LogError($"Composto com nome '{name}' não encontrado.");
        }
        return compound;
    }

    public SubstanceCompound FindCompoundById(int id)
    {
        SubstanceCompound compound = compoundsList.Find(c => c.GetId() == id);
        if (compound == null)
        {
            Debug.LogError($"Composto com ID {id} não encontrado.");
        }
        return compound;
    }

    public SubstanceSolution FindSolutionByName(string name)
    {
        SubstanceSolution solution = solutionsList.Find(s => s.GetSolutionName().Equals(name, StringComparison.OrdinalIgnoreCase));
        if (solution == null)
        {
            Debug.LogError($"Solução com nome '{name}' não encontrada.");
        }
        return solution;
    }

    public SubstanceSolution FindSolutionById(int id)
    {
        SubstanceSolution solution = solutionsList.Find(s => s.GetId() == id);
        if (solution == null)
        {
            Debug.LogError($"Solução com ID {id} não encontrada.");
        }
        return solution;
    }

    public void PrintAllSolvents()
    {
        foreach (var solvent in solventsList)
        {
            PrintSolventDetails(solvent.GetId());
        }
    }

    public void PrintAllCompounds()
    {
        foreach (var compound in compoundsList)
        {
            PrintCompoundDetails(compound.GetId());
        }
    }

    public void PrintAllSolutions()
    {
        foreach (var solution in solutionsList)
        {
            PrintSolutionDetails(solution.GetId());
        }
    }

    public void PrintSolventDetails(int solventId)
    {
        SubstanceSolvent solvent = FindSolventById(solventId);
        if (solvent.GetCompoundName() != null)
        {
            Debug.Log("Detalhes do Solvente: " + solvent.GetInfo());
        }
        else
        {
            Debug.LogError("Solvente não encontrado!");
        }
    }

    public void PrintCompoundDetails(int compoundId)
    {
        SubstanceCompound compound = FindCompoundById(compoundId);
        if (compound.GetCompoundName() != null)
        {
            Debug.Log("Detalhes do Composto Químico: " + compound.GetInfo());
        }
        else
        {
            Debug.LogError("Composto Químico não encontrado!");
        }
    }

    public void PrintSolutionDetails(int solutionId)
    {
        SubstanceSolution solution = FindSolutionById(solutionId);
        if (solution.GetSolutionName() != null)
        {
            Debug.Log("Detalhes da Solução: " + solution.GetInfo());
        }
        else
        {
            Debug.LogError("Solução não encontrada!");
        }
    }

    public void UpdateCompound(int id, string compoundName, string color, string state, float density, string groupName)
    {
        Color parsedColor = ConvertToColor(color);
        PhysicalState physicalState = ConvertToPhysicalState(state);
        GroupName parsedGroupName = ConvertToGroupName(groupName);

        SubstanceCompound compound = FindCompoundById(id);

        if (compound.GetCompoundName() != null)
        {
            Debug.Log("Antes da Atualização: " + compound.GetInfo());

            compound.UpdateCompound(id, compoundName, parsedColor, physicalState, density, parsedGroupName);

            UpdateCompoundInListAndFile(compound);

            Debug.Log("Após a Atualização: " + compound.GetInfo());
            Debug.Log("Composto atualizado com sucesso!");
        }
        else
        {
            Debug.LogError("Composto não encontrado!");
        }
    }

    private void UpdateCompoundInListAndFile(SubstanceCompound updatedCompound)
    {
        int index = compoundsList.FindIndex(c => c.GetId() == updatedCompound.GetId());
        if (index != -1)
        {
            compoundsList[index] = updatedCompound;

            int dataIndex = compoundsCollection.compounds.FindIndex(c => c.id == updatedCompound.GetId());
            if (dataIndex != -1)
            {
                compoundsCollection.compounds[dataIndex] = updatedCompound.ToCompoundData();
            }

            SaveCompounds();
        }
        else
        {
            Debug.LogError("Erro ao atualizar: composto não encontrado na lista.");
        }
    }

    public void UpdateSolvent(int id, string solventName, string color, string state, float density)
    {
        Color parsedColor = ConvertToColor(color);
        PhysicalState physicalState = ConvertToPhysicalState(state);

        SubstanceSolvent solvent = FindSolventById(id);
        Debug.Log(solvent.GetCompoundName() + "aaaaaaaaaa");
        if (solvent.GetCompoundName() != null)
        {
            Debug.Log("Antes da Atualização: " + solvent.GetInfo());

            solvent.UpdateSolvent(id, solventName, parsedColor, physicalState, density);

            UpdateSolventInListAndFile(solvent);

            Debug.Log("Após a Atualização: " + solvent.GetInfo());
            Debug.Log("Solvente atualizado com sucesso!");
        }
        else
        {
            Debug.LogError("Solvente não encontrado!");
        }
    }

    private void UpdateSolventInListAndFile(SubstanceSolvent updatedSolvent)
    {
        int index = solventsList.FindIndex(s => s.GetId() == updatedSolvent.GetId());
        if (index != -1)
        {
            solventsList[index] = updatedSolvent;

            int dataIndex = solventsCollection.solvents.FindIndex(s => s.id == updatedSolvent.GetId());
            if (dataIndex != -1)
            {
                solventsCollection.solvents[dataIndex] = updatedSolvent.ToSolventData();
            }

            SaveSolvents();
        }
        else
        {
            Debug.LogError("Erro ao atualizar: solvente não encontrado na lista.");
        }
    }



}
