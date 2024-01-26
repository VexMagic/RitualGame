using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleProjectile : Projectile
{
    [Header("AOE")]
    [SerializeField] private AOE aoe;


    protected override void OnTTLEnd()
    {
        SpawnAOE();
        base.OnTTLEnd();
    }

    private void SpawnAOE()
    {
        AOE newAOE = Instantiate(aoe);
        newAOE.Initiate(transform.position);
    }
}
