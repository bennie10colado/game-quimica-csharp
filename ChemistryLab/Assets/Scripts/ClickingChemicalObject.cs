using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingChemicalObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
    private bool isMouseOverObject = false;
    private BottleObjectCompound lastSelectedCompound;
    private BottleObjectSolvent lastSelectedSolvent;
    public GameControllerChemical gameController;
    public SubstanceManager substanceManager;

    private void Awake()
    {
        InitializeReferences();
    }

    private void InitializeReferences()
    {
        if (!gameController)
        {
            gameController = FindObjectOfType<GameControllerChemical>();
            if (!gameController)
            {
                Debug.LogError("GameControllerChemical não encontrado!");
            }
        }

        if (!substanceManager)
        {
            substanceManager = FindObjectOfType<SubstanceManager>();
            if (!substanceManager)
            {
                Debug.LogError("SubstanceManager não encontrado!");
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                BottleObjectCompound compound = hit.collider.GetComponent<BottleObjectCompound>();
                BottleObjectSolvent solvent = hit.collider.GetComponent<BottleObjectSolvent>();
                BottleSolutionObject solution = hit.collider.GetComponent<BottleSolutionObject>();

                if (compound != null)
                {
                    //Debug.Log("Composto atual: " + compound.GetInfo());
                    lastSelectedCompound = compound;
                    Debug.Log(lastSelectedCompound.GetCompoundName() + " selecionado.");
                }
                else if (solvent != null)
                {
                    //Debug.Log("Solvente atual: " + solvent.GetInfo());
                    lastSelectedSolvent = solvent;
                    Debug.Log(lastSelectedSolvent.GetCompoundName() + " selecionado.");
                }
                else if (solution != null)
                {
                    Debug.Log("Informações da Solução: " + solution.GetInfo());
                }
                else
                {
                    Debug.Log("Clique em local não registrado. Possivelmente espaço em branco/vazio.");
                }

                if (lastSelectedCompound?.GetCompoundName() != null && lastSelectedSolvent?.GetCompoundName() != null)
                {
                    StartCoroutine(PerformReaction(lastSelectedCompound, lastSelectedSolvent));

                    lastSelectedCompound = null;
                    lastSelectedSolvent = null;
                }


            }
        }
    }

    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("Solvent") || gameObject.CompareTag("Compound") || gameObject.CompareTag("Solution"))
        {
            isMouseOverObject = true;
        }
    }

    private void OnMouseExit()
    {
        isMouseOverObject = false;
    }

    private IEnumerator PerformReaction(BottleObjectCompound selectedCompound, BottleObjectSolvent selectedSolvent)
    {
        yield return new WaitForSeconds(0.01f);

        if (selectedCompound != null && selectedSolvent != null && gameController != null)
        {
            Debug.Log("Solvent ID: " + selectedSolvent.GetId() + ", Compound ID: " + selectedCompound.GetId());
            gameController.PerformReaction(selectedSolvent.GetId(), selectedCompound.GetId());
        }
    }

    private void DebugSolutionsList()
    {
        if (substanceManager && substanceManager.solutionsList != null)
        {
            foreach (var solutionObject in substanceManager.solutionsList)
            {
                Debug.Log("teste debug" + solutionObject.GetSolutionName());
            }
        }
        else
        {
            Debug.LogError("SubstanceManager ou solutionsList é null.");
        }
    }
}
