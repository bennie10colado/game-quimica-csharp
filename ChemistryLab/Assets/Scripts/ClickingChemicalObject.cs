using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingChemicalObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
    private bool isMouseOverObject = false;
    public SubstanceManager substanceManager;
    
    // Variáveis para rastrear a seleção de objetos
    private GameObject selectedCompound = null;
    private GameObject selectedSolvent = null;

    private void Update()
    {
        if (isMouseOverObject && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clique detectado no objeto com a tag: " + gameObject.tag);
            BottleObjectCompound compound = GetComponent<BottleObjectCompound>();
            BottleObjectSolvent solvent = GetComponent<BottleObjectSolvent>();
            
            if (compound != null)
            {
                Debug.Log(compound.GetInfo());

                // Selecionar o composto
                selectedCompound = gameObject;

                // Verificar se já selecionou um solvente e, se sim, iniciar a reação
                if (selectedSolvent != null)
                {
                    StartReaction();
                }
            }
            else if (solvent != null)
            {
                Debug.Log(solvent.GetInfo());

                // Selecionar o solvente
                selectedSolvent = gameObject;

                // Verificar se já selecionou um composto e, se sim, iniciar a reação
                if (selectedCompound != null)
                {
                    StartReaction();
                }
            }
            else
            {
                Debug.Log("Hepaminondas");
            }
        }
    }
    
    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("Solvent") || gameObject.CompareTag("Compound"))
        {
            isMouseOverObject = true;
        }
    }

    private void OnMouseExit()
    {
        isMouseOverObject = false;
    }

    private void StartReaction()
    {
        if (selectedCompound != null && selectedSolvent != null)
        {
            int compoundId = selectedCompound.GetComponent<BottleObjectCompound>().GetId();
            int solventId = selectedSolvent.GetComponent<BottleObjectSolvent>().GetId();
            
            // Realizar a reação
            substanceManager.PerformReaction(solventId, compoundId);
            
            // Limpar a seleção
            selectedCompound = null;
            selectedSolvent = null;
        }
    }
}
