using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public string targetTag = "ClickEvents";

    private bool zooming = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.CompareTag(targetTag))
        {
            Debug.Log("Clique detectado no objeto com a tag: ");
            zooming = true;
        }
    }

    private void Update()
    {
        if (zooming)
        {
        }
    }
}
