using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CombatSpotManager : MonoBehaviour
{
    [SerializeField] private List<CombatSpot> combatSpots;

    
    public void SetUnitSprite(List<Unit> CombatUnits)
    {
        Debug.Log("Start");
        int i = 0;
        foreach (Unit unit in CombatUnits)
        {
            combatSpots[i].SetUnitStats(unit);
            i++;
        }
    }


}
