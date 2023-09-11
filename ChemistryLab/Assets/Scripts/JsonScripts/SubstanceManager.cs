using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class ChemicalDataRoot
{
    public List<CompoundData> compounds;
}

public class SubstanceManager : MonoBehaviour
{
    public string jsonFilePath = "Assets/Resources/SolubilityData.json";

    private List<SubstanceCompound> substanceCompounds = new List<SubstanceCompound>();

    void Start()
    {
        LoadChemicalData();
        PrintCompoundList();
        //PrintSolubilityInfo();

    }

    void LoadChemicalData()
    {
        string jsonText = File.ReadAllText(jsonFilePath);
        ChemicalDataRoot dataRoot = JsonUtility.FromJson<ChemicalDataRoot>(jsonText);

        foreach (CompoundData data in dataRoot.compounds)
        {
            SubstanceCompound newCompound = new SubstanceCompound(
                data.compoundName,
                new Color(0, 0, 0, 0),
                data.physicalState,
                data.density,
                data.groupName
            );

            substanceCompounds.Add(newCompound);
        }

    }

    void PrintCompoundList()
    {
        foreach (SubstanceCompound compound in substanceCompounds)
        {
            Debug.Log("Compound Name: " + compound.GetCompoundName());
            Debug.Log("Physical State: " + compound.GetState().ToString());
            Debug.Log("Density: " + compound.GetDensity());
            Debug.Log("Compound Color: " + compound.GetColor().ToString());
            Debug.Log("Compound Group: " + compound.GetGroupName());


            Debug.Log("COMPOSTO QUÍMICO FINALIZADO \n   ");
        }
    }
}