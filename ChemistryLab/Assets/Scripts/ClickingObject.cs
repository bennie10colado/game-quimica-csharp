using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingObject : MonoBehaviour
{
    public string targetTag = "ClickEvents";
    private bool isMouseOverObject = false;

    private void Update()
    {
        if (isMouseOverObject && Input.GetMouseButtonDown(0))
        {
            Debug.LogWarning("Clique detectado no objeto com a tag: " + targetTag);
        }
    }

    private void OnMouseEnter()
    {
        if (gameObject.CompareTag(targetTag))
        {
            isMouseOverObject = true;
        }
    }

    private void OnMouseExit()
    {
        isMouseOverObject = false;
    }
}