using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected int HP;
    [SerializeField] protected int MaxHP;
    [SerializeField] protected int DMG;

    protected virtual void StartCombat()
    {
        GameManager.Instance.SetState(Gamestate.Combat, this);
    }

    public abstract void TakeDMG(int dmg);
    public abstract void Attack();
    public abstract void Die();
}
