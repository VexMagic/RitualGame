using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAOE : AOE
{
    [SerializeField] private float stunDuration;
    protected override void Effect(GameObject obj)
    {
        base.Effect(obj);
        if(obj.TryGetComponent<Villager>(out Villager villager))
            villager.AtivateVodo(true);
    }
}
