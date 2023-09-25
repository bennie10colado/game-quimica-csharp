using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSolutionObject : MonoBehaviour
{
    private SubstanceSolution solution;

    public void ConfigureSolution(SubstanceSolution solution)
    {
        this.solution = solution;
    }

    public string GetInfo()
    {
        return string.Format(
            "Solution ID: {0}" +
            ", Solution Name: {1}" +
            ", Solvent: {2}" +
            ", Compound: {3}" +
            ", Color: {4}" +
            ", State: {5}" +
            ", Density: {6}" +
            ", Solubility Result: {7}\n",
            solution.GetId(),
            solution.GetSolutionName(),
            solution.GetSolvent().GetCompoundName(), 
            solution.GetCompound().GetCompoundName(),
            ColorUtility.ToHtmlStringRGBA(solution.GetColor()),
            solution.GetState(),
            solution.GetDensity(),
            solution.GetSolubilityResult()
        );
    }
}


