using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompoundData
{
    public string compoundName;
    public string groupName;
    public string physicalState;
    public Color color;
    public float density;
    public List<SolubilityData> solubility;
}