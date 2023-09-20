using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject worldCamera;
    [SerializeField] private GameObject combatCamera;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameStateChange;
    }

    private void GameStateChange(Gamestate gamestate)
    {
        
        switch (gamestate)
        {
            case (Gamestate.exploration):
            {
                    worldCamera.SetActive(true);
                    combatCamera.SetActive(false);
            }break;
            case(Gamestate.Combat): 
            {
                worldCamera.SetActive(false);
                combatCamera.SetActive(true);
            }
            break;
        }
    }
}
