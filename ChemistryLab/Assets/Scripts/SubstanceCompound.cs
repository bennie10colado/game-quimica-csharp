using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceCompound : ChemicalCompound
{
    public SubstanceCompound(string name, Color color, PhysicalState state, float density) 
        : base(name, color, state, density)
    {
    }

    public bool IsSoluble(SubstanceSolvent solvent)
    {
        return solvent.IsSoluble(this);
    }
    
}
