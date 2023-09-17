using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerInventorySO", menuName = "Player/PlayerInventorySO")]
public class PlayerInventorySO : ScriptableObject
{
    [SerializeField] private List<Unit> unitInventory;
    public List<Unit> GetUnitsList { get { return unitInventory; } }
    public void AddUnits(Unit unit)
    { unitInventory.Add(unit); }
    public void RemoveUnits(Unit unit)
    { unitInventory.Remove(unit); }
}
