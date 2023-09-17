using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Gamestate gamestate;
    public static event Action<Gamestate> OnGameStateChanged;
    public static EnemyAbstract Enemy;
    private void Awake()
    {
        Instance = this;
    }
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
    public void SetState(Gamestate newgamestate, EnemyAbstract enemy)
    {
        gamestate = newgamestate;

        switch (gamestate)
        {
            case Gamestate.exploration:
                break;
            case Gamestate.Combat:
                Enemy = enemy;
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
