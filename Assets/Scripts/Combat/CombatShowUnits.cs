using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CombatShowUnits : MonoBehaviour
{
    [SerializeField] private Image[] unitImages = new Image[4];
    [SerializeField] private List<CombatSpot> combatSpots;

    
    public void SetUnitSprite(List<Unit> CombatUnits)
    {
        int i = 0;
        foreach (Unit unit in CombatUnits)
        {
            combatSpots[i].SetUnitStats(unit);
            i++;
        }
    }
    [ContextMenu("Set unit Sprite null")]
    public void CleanSprite()
    {
        foreach (Image x in unitImages)
        {
            x.sprite = null;
        }
    }

}
