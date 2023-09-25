using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingChemicalObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
    private bool isMouseOverObject = false;

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
            }
            else
            {
                Debug.Log("Hepaminondas");

            }
        }
    }
    

    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("ClickEvents"))
        {
            isMouseOverObject = true;
        }
    }

    private void OnMouseExit()
    {
        isMouseOverObject = false;
    }
}
