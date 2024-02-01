using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingAOE : AOE
{
    protected override void Effect(GameObject go)
    {
        base.Effect(go);
        go.GetComponent<VillagerStats>().TakeDamage(tickDamage);
    }
}
