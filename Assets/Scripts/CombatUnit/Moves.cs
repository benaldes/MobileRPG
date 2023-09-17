using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "CombatUnit/Create new Move")]
public class Moves : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string description;
    [SerializeField] private int attack;
    [SerializeField] private int accuracy;
    [SerializeField] private float speedCost;
    [SerializeField,Tooltip("Best area to attack")] private AttackZone ZoneToAttack;
    [SerializeField,Tooltip("Best area to attack from")] private AttackZone ZoneToAttackFrom;


}
[System.Serializable]
public class AttackZone
{
    [SerializeField, Range(0, 100)] public int zone1;
    [SerializeField, Range(0, 100)] public int zone2;
    [SerializeField, Range(0, 100)] public int zone3;
    [SerializeField, Range(0, 100)] public int zone4;
}
