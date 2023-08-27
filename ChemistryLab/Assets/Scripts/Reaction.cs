using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction
{
    private SubstanceCompound compound;
    private SubstanceSolvent solvent;

    public Reaction(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        this.compound = compound;
        this.solvent = solvent;
    }

    public SubstanceCompound PerformReaction()
    {
        // verifica solubilidade e densidade
        if (compound.IsSoluble(solvent) && DensitySolution(compound, solvent))
        {
            return new SubstanceCompound("Resultado da Reação", Color.white, PhysicalState.LIQUID, 1.0f);
        }
        else
        {
            // por enquanto se nao for soluvel retorna null, posteriormente retornar novas substancias que nao sao solúveis e com diferenças de fases ou corpo sólido
            return null;
        }
    }

    private bool DensitySolution(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        return true; //compound.GetDensity() > solvent.GetDensity(); 

        //se a densidade de compound for maior do que a do solvente retornar true, caso for menor retornar false e o solvente "boia"
    }
}
