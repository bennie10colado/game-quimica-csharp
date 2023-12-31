using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleObjectCompound : MonoBehaviour
{
    private int idCompound;
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;
    public Material myMaterial;

    public void ConfigureCompound(SubstanceCompound compound)
    {
        idCompound = compound.GetId();
        compoundName = compound.GetCompoundName();
        color = compound.GetColor();
        density = compound.GetDensity();
        state = compound.GetState();
        groupName = compound.GetGroupName();

        GetComponent<Renderer>().material.color = color;

        if (myMaterial != null)
        {
            myMaterial.SetColor("_Color", color);
        }
        GetComponent<Renderer>().material = myMaterial;
        GetComponent<Renderer>().material.color = color;

    }

    // Getters
    public int GetId()
    {
        return idCompound;
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

    public GroupName GetGroupName()
    {
        return groupName;
    }

    public float GetDensity()
    {
        return density;
    }

    public string GetInfo()
    {
        return "Compound Name: " + compoundName + ", Color: " + color + ", Density: " + density + ", State: " + state + ", Nome do grupo: " + groupName + ", idCompound: " + idCompound;
    }
}
