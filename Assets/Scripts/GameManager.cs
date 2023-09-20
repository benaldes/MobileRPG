using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Gamestate gamestate;
    public static event Action<Gamestate> OnGameStateChanged;
    private static List<Unit> enemyunitList;
    private void Awake()
    {
        Instance = this;
    }
    public List<Unit> EnemyUnitList { get { return enemyunitList; } }
    public void SetState(Gamestate newgamestate)
    {
        gamestate = newgamestate;

        switch (gamestate)
        {
            case Gamestate.exploration:
                break;
            case Gamestate.Combat:
                break;
        }
        OnGameStateChanged?.Invoke(gamestate);
    }
    public void SetState(Gamestate newgamestate, List<Unit> enemyUnitList)
    {
        gamestate = newgamestate;

        switch (gamestate)
        {
            case Gamestate.exploration:
                break;
            case Gamestate.Combat:
                enemyunitList = enemyUnitList;
                break;
        }
        OnGameStateChanged?.Invoke(gamestate);
    }

}

public enum Gamestate
{
    exploration,
    Combat
}
