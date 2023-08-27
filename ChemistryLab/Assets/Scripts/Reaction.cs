using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
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
        // criacao do novo composto ao verificar a solubilidade e retornar em uma instancia de objeto 3D no cenário
        //Debug.Log("Hi");
        return null;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
