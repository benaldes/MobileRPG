using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CombatSystem : MonoBehaviour
{
    public CombatState State = CombatState.NoCombat;
    [SerializeField] private Text TopBattleText;
    [SerializeField] private List<Unit> playerUnitList = new List<Unit> { };
    [SerializeField] private List<Unit> enemyUnitList;
    [SerializeField] private CombatSpotManager playerUnitsShow;
    [SerializeField] private CombatSpotManager enemyUnitsShow;

    [SerializeField] int dmg;
    [SerializeField] int attacker;
    [SerializeField] int target;
    [SerializeField] bool targetIsEnemy;
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
    private void OnCombatStateChange(CombatState combatstate)
    {
        switch(combatstate)
        {
            case CombatState.Start:
            {

            }break;
            case CombatState.Win:
            {
                    GameManager.Instance.SetState(Gamestate.exploration);
            }
            break;
        }
    }
    IEnumerator BattleStart()
    {
        State = CombatState.Start;
        yield return new WaitForSeconds(0.01f);
        ///Code for fight Start///
        CombatSetUp();
        yield return new WaitForSeconds(2);

        State = CombatState.PlayerTurn;
        PlayerTurn();
    }
    [ContextMenu("Set unit Sprite")]

    private void CombatSetUp()
    {
        playerUnitList = PlayerInventory.Instance.GetUnitsList;
        enemyUnitList = GameManager.Instance.EnemyUnitList;
        SetUnitsSprite();
    }
    private void SetUnitsSprite()
    {
        playerUnitsShow.SetUnitSprite(playerUnitList);
        enemyUnitsShow.SetUnitSprite(enemyUnitList);
    }
    [ContextMenu("attack")]
    public void chcgeUnitHpTo()
    {

        Attack( attacker, target, targetIsEnemy);
    }
    private void PlayerTurn()
    {
        TopBattleText.text = "Player Turn";
    }
    private void EnemyTurn()
    {
        TopBattleText.text = "Enemy Turn";
    }
    public void Attack(int attacker, int target, bool targetIsEnemy)
    {
        if (targetIsEnemy)
        {
            if(enemyUnitList[target].TakeDmgAndCheckIfDead(playerUnitList[attacker].Attack))
                enemyUnitList.RemoveAt(target);
        }
        else
        {
            if(playerUnitList[target].TakeDmgAndCheckIfDead(enemyUnitList[attacker].Attack))
                playerUnitList.RemoveAt(target);

        }
        CheckIfWin();
        SetUnitsSprite();
    }
    private void CheckIfWin()
    {
        if(playerUnitList.Count == 0) { OnCombatStateChange(CombatState.Lose); }
        else if(enemyUnitList.Count == 0) { OnCombatStateChange(CombatState.Win);}
    }
    public enum CombatState
    {
        NoCombat,
        Start,
        PlayerTurn,
        EnemyTurn,
        Win,
        Lose
    }
}


