using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPEvent
{
    public static Action<Vector3> OnEnemyDied;
    public static Action<GameObject> OnXPPickUp;
}
