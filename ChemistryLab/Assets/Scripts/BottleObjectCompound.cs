using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleObjectCompound : MonoBehaviour
{
    private int idCompound;
    private string compoundName;
    private Color color;
    private PhysicalState state;
    private GroupName groupName;
    private float density;
    public Material myMaterial; 

    public void ConfigureCompound(SubstanceCompound compound)
    {
        idCompound = compound.GetId();
        compoundName = compound.GetCompoundName();
        color = compound.GetColor(); 
        density = compound.GetDensity();
        state = compound.GetState();
        groupName = compound.GetGroupName();

        GetComponent<Renderer>().material.color = color;
       
        if (myMaterial != null)
        {
            myMaterial.SetColor("_Color", color);
        }
        GetComponent<Renderer>().material = myMaterial;


        Debug.Log("BottleObjectCompound configurado com " + compoundName);
    }
    
    public string GetInfo()
    {
        return "Compound Name: " + compoundName + ", Color: " + color + ", Density: " + density + ", State: " + state + ", Nome do grupo: " + groupName + ", idCompound: " + idCompound;
    }

}
