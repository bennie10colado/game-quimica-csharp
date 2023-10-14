using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingChemicalObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
    private bool isMouseOverObject = false;
    private BottleObjectCompound lastSelectedCompound;
    private BottleObjectSolvent lastSelectedSolvent;
    private void Update()
    {
        if (isMouseOverObject && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clique detectado no objeto com a tag: " + gameObject.tag);
            BottleObjectCompound compound = GetComponent<BottleObjectCompound>();
            BottleObjectSolvent solvent = GetComponent<BottleObjectSolvent>();

            if (compound != null)
            {
                Debug.Log("Composto atual: " + compound.GetInfo());

                lastSelectedCompound = compound;
                Debug.Log(lastSelectedCompound.GetCompoundName() + " selecionado.");
            }
            else if (solvent != null)
            {
                Debug.Log("Solvente atual: " + solvent.GetInfo());

                lastSelectedSolvent = solvent; 
                Debug.Log(lastSelectedSolvent.GetCompoundName() + " selecionado.");

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
}