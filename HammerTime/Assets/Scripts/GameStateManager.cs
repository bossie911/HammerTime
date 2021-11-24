using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameState currentState;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentState = GameState.Started;
    }
}
