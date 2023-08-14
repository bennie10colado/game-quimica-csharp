using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTesting : MonoBehaviour
{
    bool mouseEnteringObject;
    void Start()
    {
        mouseEnteringObject = false;

    }

    void Update()
    {
        if(mouseEnteringObject == true){
            if(Input.GetMouseButtonDown(0)){
                Debug.LogWarning("Objeto Clicado");
                //GetComponent<Light> ().enabled = !GetComponent<Light> ().enabled;
            } 
        }

    }
    void OnMouseEnter(){
        mouseEnteringObject = true;
        
    }
    void OnMouseExit(){
        mouseEnteringObject = false;
    }
}
