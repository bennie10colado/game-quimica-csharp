using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : ChemicalCompound
{
    private Dictionary<SubstanceCompound, bool> solubilityList;

    public SubstanceSolvent(string name, Color color, PhysicalState state, float density)
        : base(name, color, state, density)
    {
        solubilityList = new Dictionary<SubstanceCompound, bool>();
    }

    public void AddCompoundToList(SubstanceCompound compound, bool isSoluble) 
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
    
    public void SetSolubility(SubstanceCompound compound, bool isSoluble)
    {
        if (solubilityList.ContainsKey(compound)) 
        {
            // se o composto já existir na lista, o atualiza
            solubilityList[compound] = isSoluble;
        }
        else
        {
            AddCompoundToList(compound, isSoluble);
        }
    }
}