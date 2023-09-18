using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CombatState { Start, PlayerTurn, EnemyTurn, Win, Lose }
public class Combat : MonoBehaviour
{   
    public CombatState State;
    [SerializeField] private Text TopBattleText;
    [SerializeField] private List<Unit> enemyUnitList;
    [SerializeField] private CombatShowUnits playerUnitsShow;
    [SerializeField] private CombatShowUnits enemyUnitsShow;
    private void OnEnable()
    {
        
        State = CombatState.Start;
        StartCoroutine(BattleStart());
    }
    IEnumerator BattleStart()
    {
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
        
        enemyUnitsShow.SetUnitSprite(enemyUnitList);
    }
    
    private void PlayerTurn()
    {
        TopBattleText.text = "Player Turn";
    }
    private void EnemyTurn()
    {
        TopBattleText.text = "Enemy Turn";
    }

}


