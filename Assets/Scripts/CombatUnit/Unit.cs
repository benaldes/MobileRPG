using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Unit
{
    [SerializeField] private BaseUnit baseUnit;
    [SerializeField] private int level;
    [SerializeField] private int hp;
    [SerializeField] private int speed;


    public Unit(BaseUnit unit, int level)
    {
        this.baseUnit = unit;
        this.level = level;
        this.hp = MaxHp;
        this.speed = MaxSpeed;
    }

    public void initializeUnit()
    {
        this.hp = MaxHp;
        this.speed = MaxSpeed;
    }

    public string Name { get { return baseUnit.Name; } }
    public string Description { get { return baseUnit.Description; } }
    public Sprite Sprite { get { return baseUnit.Sprite; } }
    public int Level { get { return level; } }
    public int MaxHp { get { return Mathf.FloorToInt(baseUnit.MaxHp + (baseUnit.MaxHp * 0.1f) * level); } }
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxSpeed { get { return Mathf.FloorToInt(baseUnit.MaxSpeed + (baseUnit.MaxSpeed * 0.1f) * level); ; } }
    public int Speed { get { return speed; } }
    public int Attack { get { return Mathf.FloorToInt(baseUnit.Attack + (baseUnit.Attack * 0.1f) * level); } }
    public int Dodge { get { return Mathf.FloorToInt(baseUnit.Dodge + (baseUnit.Dodge * 0.1f) * level); } }
    public int Accuracy { get { return Mathf.FloorToInt(baseUnit.Accuracy + (baseUnit.Accuracy * 0.1f) * level); } }
    public UnitType UnitType { get { return baseUnit.UnitType; } }
    public List<MovesToUse> Moves { get { return baseUnit.Moves; } }

    public List<MovesToUse> GetUseableMoves()
    {
        List<MovesToUse> listOfMoves = new List<MovesToUse>(Moves);
        foreach (MovesToUse move in listOfMoves)
        {
            if (move.LevelToUnlock < level)
            { listOfMoves.Remove(move); }
        }
        return listOfMoves;
    }
    public bool TakeDmgAndCheckIfDead(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        { 
            HP = 0;
            return true;
        }
        return false;

    }


}
[System.Serializable]
public class MovesToUse
{
    [SerializeField] private Moves moves;
    [SerializeField] private int levelToUnlock;
    public int LevelToUnlock { get { return levelToUnlock; } }
}

