using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChemicalCompound
{
    string GetCompoundName();
    Color GetColor();
    PhysicalState GetState();
    float GetDensity();
}
