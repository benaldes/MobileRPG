using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatUnit", menuName = "CombatUnit/Create new Unit")]
public class Unit : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField, TextArea] private string description;
    [SerializeField] private int level = 0;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int dodge;
    [SerializeField] private int accuracy;
    [SerializeField] private int speed;
    [SerializeField] private int maxSpeed;
    [SerializeField] private UnitType unitType;
    [SerializeField] private List<MovesToUse> moves;
    public string Name { get { return _name; } }
    public string Description { get { return description; } }
    public int Level { get { return level; } }
    public Sprite Sprite { get { return sprite; } }
    public int HP { get { return hp; } }
    public int MaxHp { get { return Mathf.FloorToInt(maxHp + (maxHp * 0.1f) * level); } }
    public int Attack { get { return Mathf.FloorToInt(attack + (attack * 0.1f) * level); } }
    public int Dodge { get { return Mathf.FloorToInt(dodge + (dodge * 0.1f) * level); } }
    public int Accuracy { get { return Mathf.FloorToInt(accuracy + (accuracy * 0.1f) * level); } }
    public int Speed { get { return Mathf.FloorToInt(speed + (speed * 0.1f) * level); } }
    public int MaxSpeed { get { return Mathf.FloorToInt(maxSpeed + (maxSpeed * 0.1f) * level); ; } }
    public UnitType UnitType { get { return unitType; } }
    public List<MovesToUse> Moves { get { return moves; } }
    public List<MovesToUse> ReturnUseableMoves()
    {
        List<MovesToUse> listOfMoves = new List<MovesToUse>(moves);
        foreach (MovesToUse move in listOfMoves)
        {
            if (move.LevelToUnlock < level)
            { listOfMoves.Remove(move); }
        }
        return listOfMoves;
    }
}
[System.Serializable]
public class MovesToUse
{
    [SerializeField] private Moves moves;
    [SerializeField] private int levelToUnlock;
    public int LevelToUnlock { get { return levelToUnlock; } }
}
public enum UnitType
{
    Warrior,
    Ranger,
    Healer,
    Bard
}
