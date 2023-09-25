using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameControllerChemical gameController;

    void Start()
    {
        gameController = GetComponent<GameControllerChemical>();
    }
}
