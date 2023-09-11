using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameController gameController;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }
}
