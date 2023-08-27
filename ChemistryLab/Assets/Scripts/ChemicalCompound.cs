using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalCompound : MonoBehaviour
{
    private string name;
    private Color color;
    private PhysicalState state;
    private float density;

    public ChemicalCompound(string name, Color color, PhysicalState state, float density)
    {
        this.name = name;
        this.color = color;
        this.state = state;
        this.density = density;
    }

    public string GetName()
    {
        return name;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
