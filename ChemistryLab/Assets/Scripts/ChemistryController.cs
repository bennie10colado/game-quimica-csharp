using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemistryController : MonoBehaviour
{
    public SubstanceCompound CreateCompound(string name, Color color, PhysicalState state, float density)
    {
        return null;
    }    
    
    public SubstanceSolvent CreateSolvent(string name, Color color, PhysicalState state, float density)
    {
        return null;
    }

    public SubstanceCompound MixSubstances(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        Reaction reaction = new Reaction(compound, solvent);
        return reaction.PerformReaction();
    }

    public bool CheckSolubility(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        return true; //por enquanto deixa true, enquanto nao analisamos a melhor forma de analisar a solubilidade entre 2 compostos
    }
}
