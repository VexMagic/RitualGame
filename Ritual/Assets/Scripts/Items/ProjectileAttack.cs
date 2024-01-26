using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : TimedAttack
{

    [Header("Projectile")]
    [SerializeField] protected Transform projectileSpawnpoint;
    [SerializeField] protected Projectile prefab;


    protected override void Attack()
    {
        Vector3 firingDir = GetFiringDir();
        SpawnProjectile(firingDir);
    }

    private void SpawnProjectile(Vector3 firingDir)
    {
        Projectile projectile = Instantiate(prefab);
        projectile.Initiate(projectileSpawnpoint.position, firingDir);
        projectile.Fire();
    }

    private Vector3 GetFiringDir()
    {
        //find enemy
        //Transform enemy;
        return Vector3.zero - projectileSpawnpoint.position;

    }
}
