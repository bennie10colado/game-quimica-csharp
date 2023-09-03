using UnityEngine;

public class SubstanceCompound : MonoBehaviour, IChemicalCompound
{
    [SerializeField] private string compoundName;
    [SerializeField] private Color color;
    [SerializeField] private PhysicalState state;
    [SerializeField] private float density;

  	//construtor pois não estava sendo possivel instanciar o objeto SubstanceCompound na Reaction 
	public SubstanceCompound(string compoundName, Color color, PhysicalState state, float density)
    {
        this.compoundName = compoundName;
        this.color = color;
        this.state = state;
        this.density = density;
    }	
	
    public string GetCompoundName()
    {
        return compoundName;
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
	
	//obs: pode-se criar no futuro um método para analisar a solubilidade do composto com um solvente, ou com outros compostos. Semelhante ao IsSoluble
}
