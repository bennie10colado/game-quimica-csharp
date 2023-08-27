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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
