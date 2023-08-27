using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTwo : MonoBehaviour
{
    public enum SolubilityResult
    {
        Soluble,
        InsolubleHighDensity,
        InsolubleLowDensity
    }
    
    private SubstanceSolvent aguaDestilada;
    [SerializeField] private GameObject waterObject; 

    private void Start()
    {
        aguaDestilada = waterObject.GetComponent<SubstanceSolvent>();
    
        if (aguaDestilada == null)
        {
            Debug.LogError("Componente SubstanceSolvent não encontrado no objeto da água destilada!");
            return;
        }

        SubstanceCompound etanoato = new SubstanceCompound("Etanoato de Etila", Color.yellow, PhysicalState.LIQUID, 0.9f);
        SubstanceCompound butanoato = new SubstanceCompound("Butanoato de Sódio", Color.green, PhysicalState.SOLID, 1.2f);

        aguaDestilada.SetSolubility(etanoato, true);
        aguaDestilada.SetSolubility(butanoato, true);

        SolubilityResult resultEtanoato = CheckSolubility(aguaDestilada, etanoato);
        SolubilityResult resultButanoato = CheckSolubility(aguaDestilada, butanoato);

        Debug.Log("Etanoato: " + resultEtanoato);
        Debug.Log("Butanoato: " + resultButanoato);
    }

    private SolubilityResult CheckSolubility(SubstanceSolvent solvent, SubstanceCompound compound)
    {
        if (solvent.IsSoluble(compound))
        {
            if (compound.GetDensity() > solvent.GetDensity())
            {
                return SolubilityResult.InsolubleHighDensity; // I↑
            }
            else
            {
                return SolubilityResult.Soluble; // S
            }
        }
        else
        {
            return SolubilityResult.InsolubleLowDensity; // I↓
        }
    }
}