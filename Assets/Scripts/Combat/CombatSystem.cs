using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CombatSystem : MonoBehaviour
{   
    public CombatState State = CombatState.NoCombat;
    [SerializeField] private Text TopBattleText;
    [SerializeField] private List<Unit> enemyUnitList;
    [SerializeField] private CombatSpotManager playerUnitsShow;
    [SerializeField] private CombatSpotManager enemyUnitsShow;
    private void Awake()
    {

        GameManager.OnGameStateChanged += OnGameStateChange;
    }
    private void OnGameStateChange(Gamestate gamestate)
    {
        switch (gamestate)
        {
            case Gamestate.Combat:
                {
                    StartCoroutine(BattleStart());
                }
                break;
            case Gamestate.exploration:
                {
                    State = CombatState.NoCombat;
                }
                break;
        }
    }
    IEnumerator BattleStart()
    {
        State = CombatState.Start;
        yield return new WaitForSeconds(0.01f);
        ///Code for fight Start///
        SetUnitsSprite();
        yield return new WaitForSeconds(2);
        
        State = CombatState.PlayerTurn;
        PlayerTurn();
    }
    [ContextMenu("Set unit Sprite")]
    private void SetUnitsSprite()
    {
        playerUnitsShow.SetUnitSprite(PlayerInventory.Instance.GetUnitsList);
        Debug.LogWarning("b");
        enemyUnitsShow.SetUnitSprite(GameManager.Instance.EnemyUnitList);
    }
    
    private void PlayerTurn()
    {
        TopBattleText.text = "Player Turn";
    }
    private void EnemyTurn()
    {
        TopBattleText.text = "Enemy Turn";
    }
    public enum CombatState {
        NoCombat,
        Start,
        PlayerTurn,
        EnemyTurn,
        Win,
        Lose
    }
}


