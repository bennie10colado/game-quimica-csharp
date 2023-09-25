using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : MonoBehaviour, IChemicalCompound
{
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;

    public SubstanceSolvent(string compoundName, Color color, PhysicalState state, float density)
    {
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
        this.groupName = GroupName.Solvent;
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
}
