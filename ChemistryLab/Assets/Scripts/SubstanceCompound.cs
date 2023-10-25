using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubstanceCompound : MonoBehaviour, IChemicalCompound
{
    private int idCompound;
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;

    //construtor pois não estava sendo possivel instanciar o objeto SubstanceCompound na Reaction 
    public SubstanceCompound(int id, string compoundName, Color color, PhysicalState state, float density, GroupName groupName)
    {
        this.idCompound = id;
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
        this.groupName = groupName;
    }


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

    public float GetDensity()
    {
        return density;
    }

    public GroupName GetGroupName()
    {
        return groupName;
    }

    public string GetInfo()
    {
        return $"ID: {GetId()}, Nome: {GetCompoundName()}, Cor: {GetColor()}, Estado: {GetState()}, Densidade: {GetDensity()}, Grupo: {GetGroupName()}";
    }
}
