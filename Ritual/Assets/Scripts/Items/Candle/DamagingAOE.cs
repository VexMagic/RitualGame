using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingAOE : AOE
{
    protected override void Effect(GameObject obj)
    {
        base.Effect(obj);
        Debug.Log("damage " + obj.name);
    }
}
