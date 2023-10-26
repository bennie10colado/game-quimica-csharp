using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubstanceCompoundExtension
{
    public static CompoundData ToCompoundData(this SubstanceCompound compound)
    {
        return new CompoundData
        {
            id = compound.GetId(),
            compoundName = compound.GetCompoundName(),
            color = compound.GetColor().ToString(),
            state = System.Enum.GetName(typeof(PhysicalState), compound.GetState()),
            density = compound.GetDensity(),
            groupName = System.Enum.GetName(typeof(GroupName), compound.GetGroupName())
        };

    }
}
