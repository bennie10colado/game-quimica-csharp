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
            Debug.Log("Outline component not found on the object.");
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
        int clickEventsLayer2 = LayerMask.NameToLayer("Default");
        
        if (gameObject.layer == clickEventsLayer || gameObject.layer == clickEventsLayer2)
        {
            //Debug.Log("Clique detectado pelo outline!!!!!!");
			
			//continuar para receber camera lentamente ou entao mudar de cena
			//SceneManager.LoadScene("NomeDaCenaDoModoDeJogo");
        }
    }
}
