using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

[System.Serializable]
public class CompoundsCollection
{
    public List<CompoundData> compounds;
}

public class SubstanceManager : MonoBehaviour
{
    public string jsonFilePath = "Assets/Resources/SolubilityData.json";

    private List<SubstanceCompound> substanceCompounds = new List<SubstanceCompound>();
    private Dictionary<string, SubstanceSolvent> solvents = new Dictionary<string, SubstanceSolvent>();

    void Start()
    {
        LoadChemicalData();
        PrintCompoundList();
    }

    void LoadChemicalData()
    {
        string jsonText = File.ReadAllText(jsonFilePath);
        CompoundsCollection dataRoot = JsonUtility.FromJson<CompoundsCollection>(jsonText);

        if (dataRoot?.compounds == null)
        {
            Debug.LogError("dataRoot é null ou dataRoot.compounds é null.");
            return;
        }

        foreach (CompoundData data in dataRoot.compounds)
        {
            if (data == null)
            {
                Debug.LogError("data é null.");
                continue;
            }

            if (data.solubility == null)
            {
                Debug.LogError($"data.solubility é null para o composto {data.compoundName}.");
                continue;
            }

            Dictionary<SubstanceSolvent, string> solubilityTable = new Dictionary<SubstanceSolvent, string>();

            foreach (var entry in data.solubility)
            {
                if (string.IsNullOrEmpty(entry.Key) || string.IsNullOrEmpty(entry.Value))
                {
                    Debug.LogError("entry.Key ou entry.Value é null ou vazio.");
                    continue;
                }

                SubstanceSolvent solvent = GetSolventByName(entry.Key);
                if (solvent == null)
                {
                    Debug.LogError($"Solvente {entry.Key} retornou null.");
                    continue;
                }

                solubilityTable[solvent] = entry.Value;
                solvents[entry.Key] = solvent;
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
