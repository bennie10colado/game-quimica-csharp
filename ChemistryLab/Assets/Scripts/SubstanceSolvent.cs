using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : MonoBehaviour, IChemicalCompound
{
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private float density;
    private string groupName;
    private Dictionary<SubstanceCompound, bool> solubilityTable;

    public SubstanceSolvent(string compoundName, Color color, PhysicalState state, float density, string groupName)
    {
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
        this.groupName = groupName;
    }

    //testes para ler o JSON

    //public void LoadSolubilityData(string json) {
    //SolubilityData data = JsonUtility.FromJson<SolubilityData>(json);
    // converter solubilityTable em data
    //}

    //public string SaveSolubilityData() {
    //SolubilityData data = new SolubilityData();
    // converter solubilityTable para data
    //return JsonUtility.ToJson(data);
    //}

    private void Awake()
    {
        solubilityTable = new Dictionary<SubstanceCompound, bool>();

        //LoadData();
    }


    public void SetSolubility(SubstanceCompound compound, bool isSoluble)
    {
        if (solubilityTable.ContainsKey(compound))
        {
            solubilityTable[compound] = isSoluble;
        }
        else
        {
            solubilityTable.Add(compound, isSoluble);
        }
    }

    public bool IsSoluble(SubstanceCompound compound)
    {
        if (solubilityTable.ContainsKey(compound))
        {
            return solubilityTable[compound];
        }
        return false;
    }

    public string GetCompoundName()
    {
        return compoundName;
    }

    public Color GetColor()
    {
        return color;
    }

    public PhysicalState GetState()
    {
        return state;
    }

    public float GetDensity()
    {
        return density;
    }
}
