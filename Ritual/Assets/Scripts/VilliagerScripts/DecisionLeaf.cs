using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionLeaf : DecisionNode
{
    public Action action;
    public override void MakeDecision()
    {
        action?.Invoke();
    }
}
