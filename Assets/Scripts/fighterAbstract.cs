using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class fighterAbstract : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected int HP;
    [SerializeField] protected int MaxHP;
    [SerializeField] protected int DMG;

    public abstract void TakeDMG(int dmg);
    public abstract void Attack();
    public abstract void Die();
}
