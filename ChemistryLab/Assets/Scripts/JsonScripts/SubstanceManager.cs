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

public class SubstanceManager : MonoBehaviour
{
    public string compoundsJsonFilePath = "Assets/Resources/SolubilityData.json";
    public string solventsJsonFilePath = "Assets/Resources/SolventsData.json";

    private Dictionary<string, SubstanceSolvent> solvents = new Dictionary<string, SubstanceSolvent>();
    private List<SubstanceCompound> substanceCompounds = new List<SubstanceCompound>();

    void Start()
    {
        LoadSolvents();
        LoadChemicalData();
        PrintCompoundList();
    }
    void LoadSolvents()
    {
        string jsonText = File.ReadAllText(solventsJsonFilePath);
        SolventsCollection solventsCollection = JsonUtility.FromJson<SolventsCollection>(jsonText);

        foreach (var solventData in solventsCollection.solvents)
        {
            SubstanceSolvent newSolvent = new SubstanceSolvent(
                solventData.name,
                solventData.color,
                solventData.state,
                solventData.density
            );
        
            solvents[solventData.name] = newSolvent;
        }
    }


    void LoadChemicalData()
    {
        string jsonText = File.ReadAllText(compoundsJsonFilePath);

        Debug.Log(jsonText);

        CompoundsCollection dataRoot = JsonUtility.FromJson<CompoundsCollection>(jsonText);

        if (dataRoot.compounds == null)
        {
            Debug.Log("dataRoot é null ou dataRoot.compounds é null.");
            return;
        }

        foreach (CompoundData data in dataRoot.compounds)
        {
            if (data.solubility == null)
            {
                Debug.Log($"data.solubility é null para o composto {data.compoundName}.");
                continue;
            }

            Dictionary<SubstanceSolvent, string> solubilityTable = new Dictionary<SubstanceSolvent, string>();

            foreach (var entry in data.solubility)
            {
                if (string.IsNullOrEmpty(entry.solvent) || string.IsNullOrEmpty(entry.value))
                {
                    Debug.Log($"entry.solvent ou entry.value é null ou vazio para o composto {data.compoundName}.");
                    continue;
                }

                SubstanceSolvent solvent = GetSolventByName(entry.solvent);
                if (solvent == null)
                {
                    Debug.Log($"Solvente {entry.solvent} retornou null para o composto {data.compoundName}.");
                    continue;
                }

                solubilityTable[solvent] = entry.value;
                if (!solvents.ContainsKey(entry.solvent))
                {
                    solvents[entry.solvent] = solvent;
                }
            }

            PhysicalState state;
            GroupName groupName;

            try
            {
                state = (PhysicalState)Enum.Parse(typeof(PhysicalState), data.physicalState);
                groupName = (GroupName)Enum.Parse(typeof(GroupName), data.groupName);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Erro ao fazer parse dos enums para o composto {data.compoundName}. Mensagem: {ex.Message}");
                continue;
            }

            SubstanceCompound newCompound = new SubstanceCompound(
                data.compoundName,
                data.color,
                state,
                data.density,
                groupName
            );

            substanceCompounds.Add(newCompound);
        }
    }
    
    public SubstanceSolvent GetSolventByName(string solventName)
    {
        if (solvents.TryGetValue(solventName, out var solvent))
        {
            return solvent;
        }
        else
        {
            Debug.LogError($"Solvente {solventName} não encontrado.");
            return null;
        }
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
