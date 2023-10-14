using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSolution : MonoBehaviour
{
    private int id;
    private int idSolvent;
    private int idCompound;
    private string solutionName;
    private Color color;
    private PhysicalState state;
    private float density;
    private SolubilityResults solubilityResult;

    public SubstanceSolution(int id, int solvent, int compound, string solutionName, Color color, PhysicalState state, float density, SolubilityResults solubilityResult)
    {
        this.id = id;
        this.idSolvent = solvent;
        this.idCompound = compound;
        this.solutionName = solutionName;
        this.color = color;
        this.state = state;
        this.density = density;
        this.solubilityResult = solubilityResult;
    }

    public int GetId() => id;
    public int GetSolventId() => idSolvent;
    public int GetCompoundId() => idCompound;
    public string GetSolutionName() => solutionName;
    public Color GetColor() => color;
    public PhysicalState GetState() => state;
    public float GetDensity() => density;
    public SolubilityResults GetSolubilityResult() => solubilityResult;

}
