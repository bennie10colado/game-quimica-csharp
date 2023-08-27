using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickingObject : MonoBehaviour
{
    public LayerMask clickEventsLayer;
	public string sceneName;
    private bool isMouseOverObject = false;

    private void Update()
    {
        if (isMouseOverObject && Input.GetMouseButtonDown(0))
        {
            Debug.LogWarning("Clique detectado no objeto com a tag: " + gameObject.tag);
            ChangeScene(sceneName);
        }
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
