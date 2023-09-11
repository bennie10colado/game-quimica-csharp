using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubstanceCompound : MonoBehaviour, IChemicalCompound
{
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private float density;
    private string groupName;
    private Dictionary<SubstanceSolvent, bool> solubilityTable;


    //construtor pois não estava sendo possivel instanciar o objeto SubstanceCompound na Reaction 
    public SubstanceCompound(string compoundName, Color color, PhysicalState state, float density, string groupName)
    {
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
        this.groupName = groupName;
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

    public string GetGroupName()
    {
        return groupName;
    }

    public Dictionary<SubstanceSolvent, bool> GetSolubilityTable()
    {
        return solubilityTable;
    }
    //obs: pode-se criar no futuro um método para analisar a solubilidade do composto com um solvente, ou com outros compostos. Semelhante ao IsSoluble
}
