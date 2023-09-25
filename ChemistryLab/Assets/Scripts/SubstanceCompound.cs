using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubstanceCompound : MonoBehaviour, IChemicalCompound
{
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;
    private Dictionary<SubstanceSolvent, string> solubilityTable;

    //construtor pois não estava sendo possivel instanciar o objeto SubstanceCompound na Reaction 
	public SubstanceCompound(string compoundName, Color color, PhysicalState state, float density, GroupName groupName)
	{
    this.compoundName = compoundName;
    this.color = color;
    this.state = state;
    this.density = density;
    this.groupName = groupName;
    this.solubilityTable = new Dictionary<SubstanceSolvent, string>();
	}

	public void AddSolubilityInfo(SubstanceSolvent solvent, string isSoluble)
	{
    solubilityTable[solvent] = isSoluble;
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

    public GroupName GetGroupName()
    {
        return groupName;
    }

    public Dictionary<SubstanceSolvent, string> GetSolubilityTable()
    {
        return solubilityTable;
    }
    //obs: pode-se criar no futuro um método para analisar a solubilidade do composto com um solvente, ou com outros compostos.
}
