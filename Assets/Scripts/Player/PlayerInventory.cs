using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [SerializeField] private PlayerInventorySO inventory;
    private void Awake()
    {
        Instance = this;
        foreach (var unit in GetUnitsList)
        {
            unit.initializeUnit();
        }
    }
    
    public List<Unit> GetUnitsList { get { return inventory.GetUnitsList; } }
    public void AddUnitToInventory(Unit unit)
    {
        unit.initializeUnit();
        inventory.AddUnits(unit);
    }
}
