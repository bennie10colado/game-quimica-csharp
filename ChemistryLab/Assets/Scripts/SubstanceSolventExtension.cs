using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubstanceSolventExtension
{
    public static SolventData ToSolventData(this SubstanceSolvent solvent)
    {
        return new SolventData
        {
            id = solvent.GetId(),
            compoundName = solvent.GetCompoundName(),
            color = solvent.GetColor().ToString(),
            state = System.Enum.GetName(typeof(PhysicalState), solvent.GetState()),
            density = solvent.GetDensity(),
        };
    }
}
