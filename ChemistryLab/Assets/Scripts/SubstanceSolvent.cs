using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : MonoBehaviour, IChemicalCompound
{
    [SerializeField] private string compoundName;
    [SerializeField] private Color color;
    [SerializeField] private PhysicalState state;
    [SerializeField] private float density;

    private Dictionary<SubstanceCompound, bool> solubilityTable;

    private void Awake()
    {
        solubilityTable = new Dictionary<SubstanceCompound, bool>();
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
