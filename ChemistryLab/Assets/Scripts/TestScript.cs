using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameControllerTwo gameControllerTwo;

    void Start()
    {
        gameControllerTwo = GetComponent<GameControllerTwo>();

    }
}
