using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BaseEnemyWorld : MonoBehaviour
{
    [SerializeField] private List<Unit> enemyUnitList;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.Instance.SetState(Gamestate.Combat, enemyUnitList);
        }

    }
 
    private void Awake()
    {
        foreach (var unit in enemyUnitList)
        {
            unit.initializeUnit();
        }
    }
}
