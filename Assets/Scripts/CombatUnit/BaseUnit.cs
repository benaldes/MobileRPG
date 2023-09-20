using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseCombatUnit", menuName = "CombatUnit/Create new BaseUnit")]
public class BaseUnit : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField, TextArea] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int dodge;
    [SerializeField] private int accuracy;
    [SerializeField] private int maxSpeed;
    [SerializeField] private UnitType unitType;
    [SerializeField] private List<MovesToUse> moves;
    public string Name { get { return _name; } }
    public string Description { get { return description; } }
    public Sprite Sprite { get { return sprite; } }
    public int MaxHp { get { return maxHp;  } }
    public int Attack { get { return attack; } }
    public int Dodge { get { return dodge; } }
    public int Accuracy { get { return accuracy; } }
    public int MaxSpeed { get { return maxSpeed; } }
    public UnitType UnitType { get { return unitType; } }
    public List<MovesToUse> Moves { get { return moves; } }
   
}

public enum UnitType
{
    Warrior,
    Ranger,
    Healer,
    Bard
}
