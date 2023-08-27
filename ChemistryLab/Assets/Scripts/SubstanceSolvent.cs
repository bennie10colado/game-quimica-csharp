using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : ChemicalCompound
{
    private Dictionary<SubstanceCompound, bool> solubilityList = new Dictionary<SubstanceCompound, bool>();

    public SubstanceSolvent(string name, Color color, PhysicalState state, float density) 
        : base(name, color, state, density)
    {   
    }

    public void AddSolubility(SubstanceCompound compound, bool isSoluble)
    {
        solubilityList.Add(compound, isSoluble);
    }

    public bool IsSoluble(SubstanceCompound compound)
    {
        if (solubilityList.ContainsKey(compound))
        {
            return solubilityList[compound];
        }
        return false;
    }
}

