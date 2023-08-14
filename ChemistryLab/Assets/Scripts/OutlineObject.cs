using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
	private Outline outline;
    private bool mouseOver = false;

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
			mouseOver = true;
        }
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        if (mouseOver)
        {
		//Debug.LogWarning("hello");
		
        }
    }
}