using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubstanceSolutionExtension
{
    public static SolubilityData ToSolutionData(this SubstanceSolution solution)
    {
        return new SolubilityData
        {
            id = solution.GetId(),
            solventId = solution.GetSolventId(),
            compoundId = solution.GetCompoundId(),
            solutionName = solution.GetSolutionName(),
            color = solution.GetColor().ToString(),
            state = System.Enum.GetName(typeof(PhysicalState), solution.GetState()),
            density = solution.GetDensity(),
            solubilityResult = System.Enum.GetName(typeof(SolubilityResults), solution.GetSolubilityResult())
        };
    }
}
