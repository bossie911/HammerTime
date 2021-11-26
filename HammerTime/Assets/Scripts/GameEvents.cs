using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action startHammering;
    public void StartFleeing()
    {
        if (startHammering != null)
        {
            startHammering();
        }
    }

    public event Action hammerTimeOver;
    public void StartChasing()
    {
        if (hammerTimeOver != null)
        {
            hammerTimeOver();
        }
    }
}
