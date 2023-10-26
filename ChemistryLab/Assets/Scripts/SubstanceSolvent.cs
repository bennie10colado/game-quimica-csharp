using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolvent : MonoBehaviour, IChemicalCompound
{
    private int idSolvent;
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private float density;

    public SubstanceSolvent(int id, string compoundName, Color color, PhysicalState state, float density)
    {
        this.idSolvent = id;
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
    }
    public int GetId()
    {
        return idSolvent;
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

    public string GetInfo()
    {
        return $"ID: {GetId()}, Nome: {GetCompoundName()}, Cor: {GetColor()}, Estado: {GetState()}, Densidade: {GetDensity()}";
    }

    public void UpdateSolvent(int id, string name, Color color, PhysicalState state, float density)
    {
        this.idSolvent = id;
        this.compoundName = name;
        this.color = color;
        this.state = state;
        this.density = density;
    }

}
