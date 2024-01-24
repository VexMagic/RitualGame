using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificialDagger : TimedAttack
{
    [SerializeField] private LayerMask toDamage;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Vector2 size;

    protected override void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll(centerPoint.position, size, 0, toDamage);
        DamageEnemies(enemies);
    }

    private void DamageEnemies(Collider2D[] enemies)
    {
        foreach (Collider2D enemy in enemies)
            DamageEnemy(enemy);
    }

    private void DamageEnemy(Collider2D enemy)
    {
        Debug.Log("damage enemy");
    }

    private void OnDrawGizmos()
    {
        if (centerPoint != null && size != null)
            Gizmos.DrawWireCube(centerPoint.position, size);
    }
}
