using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : TimedAttack
{
    //the radius to check for enemies - used to find closes enemy to fire towards
    [SerializeField] protected float attackRange;
    [SerializeField] LayerMask enemyLayer;
    [Header("Projectile")]
    [SerializeField] protected Transform projectileSpawnpoint;
    [SerializeField] protected Projectile prefab;


    protected override void Attack()
    {
        Collider2D closestEnemy = GetClosestEnemy();

        if (closestEnemy == null) //no enemy dont fire
            return;
        Vector3 firingDir = GetFiringDir(closestEnemy.transform.position);

        SpawnProjectile(firingDir);
    }

    private void SpawnProjectile(Vector3 firingDir)
    {
        Projectile projectile = Instantiate(prefab);
        projectile.Initiate(projectileSpawnpoint.position, firingDir);
        projectile.Fire();
    }

    private Vector3 GetFiringDir(Vector3 enemyPos)
    {
        return (enemyPos - projectileSpawnpoint.position).normalized;

    }

    private Collider2D GetClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        Collider2D closest;

        if (enemies.Length <= 0)
            return null;
        else if (enemies.Length == 1)
            return enemies[0];
        else
            closest = enemies[0];

        //loop thru list and find whichever is closes
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector2.Distance(transform.position, closest.transform.position) > Vector2.Distance(transform.position, enemies[i].transform.position))
                closest = enemies[i];
        }
        return closest;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
