using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalCompound
{
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private float density;

    public ChemicalCompound(string name, Color color, PhysicalState state, float density)
    {
        this.compoundName = name;
        this.color = color;
        this.state = state;
        this.density = density;
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
}
