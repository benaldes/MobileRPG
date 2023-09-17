using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubToEventTest : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChange;
    }
    private void OnGameStateChange(Gamestate gamestate)
    {
        if(gamestate == Gamestate.exploration)
        {
            ///do this code
        }
    }
}
