using UnityEngine;

public class TreantExplore : EnemyAbstract
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            StartCombat();
    }
    public override void TakeDMG(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            ///Code For death///
        }
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
