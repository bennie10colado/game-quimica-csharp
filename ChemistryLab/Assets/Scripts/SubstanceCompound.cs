using UnityEngine;

public class SubstanceCompound : MonoBehaviour, IChemicalCompound
{
    [SerializeField] private string compoundName;
    [SerializeField] private Color color;
    [SerializeField] private PhysicalState state;
    [SerializeField] private float density;

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
	
	public bool IsSoluble(SubstanceCompound compound){
		return true;
	}
}
