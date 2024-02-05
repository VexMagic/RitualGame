using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAOE : AOE
{
    [SerializeField] private float stunDuration;
    protected override void Effect(GameObject obj)
    {
        base.Effect(obj);
        Debug.Log("Stun " + obj.name + " for " + stunDuration + "s");
        Debug.Log("Damage " + obj.name);
        //call activate voodoo from enemy
    }
}
