using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSolutionObject : MonoBehaviour
{
    private SubstanceSolution solution;

    public void ConfigureSolution(SubstanceSolution solution)
    {
        this.solution = solution;
        ApplyColorToMaterial(solution.GetColor());

    }

    public void ApplyColorToMaterial(Color color)
    {
        Renderer renderer = this.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    // Getters
    public int GetId()
    {
        return solution.GetId();
    }

    public string GetSolutionName()
    {
        return solution.GetSolutionName();
    }

    public int GetSolventId()
    {
        return solution.GetSolventId();
    }

    public int GetCompoundId()
    {
        return solution.GetCompoundId();
    }

    public Color GetColor()
    {
        return solution.GetColor();
    }

    public PhysicalState GetState()
    {
        return solution.GetState();
    }

    public float GetDensity()
    {
        return solution.GetDensity();
    }

    public SolubilityResults GetSolubilityResult()
    {
        return solution.GetSolubilityResult();
    }

    public string GetInfo()
    {
        return string.Format(
            "Solution ID: {0}" +
            ", Solution Name: {1}" +
            ", SolventId: {2}" +
            ", CompoundId: {3}" +
            ", Color: {4}" +
            ", State: {5}" +
            ", Density: {6}" +
            ", Solubility Result: {7}\n",
            GetId(),
            GetSolutionName(),
            GetSolventId(),
            GetCompoundId(),
            ColorUtility.ToHtmlStringRGBA(GetColor()),
            GetState(),
            GetDensity(),
            GetSolubilityResult()
        );
    }
}
