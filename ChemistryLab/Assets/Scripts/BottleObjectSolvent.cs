using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleObjectSolvent : MonoBehaviour
{
    private int idSolvent;
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;
    public Material myMaterial; 
    
    public void ConfigureSolvent(SubstanceSolvent solvent)
    {
        idSolvent = solvent.GetId();
        compoundName = solvent.GetCompoundName();
        color = solvent.GetColor(); 
        density = solvent.GetDensity();
        state = solvent.GetState();
        groupName = solvent.GetGroupName();

        if (myMaterial != null)
        {
            myMaterial.SetColor("_Color", color);
        }
        GetComponent<Renderer>().material = myMaterial;


        GetComponent<Renderer>().material.color = color;
        Debug.Log("BottleObjectSolvent configurado com " + compoundName);
    }
    
    public string GetInfo()
    {
        return "Solvent Name: " + compoundName + ", Color: " + color + ", Density: " + density + ", State: " + state + ", nome do grupo: " + groupName + ", idSolvent: " + idSolvent;
    }
    
}
