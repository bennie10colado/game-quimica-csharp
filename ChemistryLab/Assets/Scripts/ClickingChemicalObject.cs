using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingChemicalObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
    private bool isMouseOverObject = false;
    public SubstanceManager substanceManager; // Você pode configurar isso no Unity Inspector

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
            }
            else if (solvent != null)
            {
                Debug.Log(solvent.GetInfo());

                // Realize a reação com base nos IDs do solvente e do composto
                PerformReaction(solvent.GetId(), compound.GetSubstanceCompound().id);
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

    // Função para realizar a reação com base nos IDs do solvente e do composto
    private void PerformReaction(int solventId, int compoundId)
    {
        // Consulte seu banco de dados (ou JSON) para obter informações sobre a reação
        // Implemente a lógica da reação com base nos IDs
        // Aqui está um exemplo simples:

        // Consulte o banco de dados de reações para encontrar a reação com solventeId e compoundId
        ReactionData reaction = substanceManager.GetReactionData(solventId, compoundId);

        if (reaction != null)
        {
            Debug.Log("Reação realizada: " + reaction.solutionName);
            // Atualize o cenário com base na reação, por exemplo, crie um novo objeto para representar a solução resultante.
        }
        else
        {
            Debug.Log("Reação não encontrada para solventeId: " + solventId + " e compoundId: " + compoundId);
        }
    }
}
