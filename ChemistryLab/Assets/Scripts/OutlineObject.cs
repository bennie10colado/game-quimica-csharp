using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
        else
        {
            Debug.LogWarning("Outline component not found on the object.");
        }
    }

    private void OnMouseEnter()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        int clickEventsLayer = LayerMask.NameToLayer("ClickEvents");
        
        if (gameObject.layer == clickEventsLayer)
        {
            Debug.LogWarning("Clique detectado!!!!!!!!!!!!!");
			//continuar para receber camera lentamente ou entao mudar de cena
        }
    }
}
