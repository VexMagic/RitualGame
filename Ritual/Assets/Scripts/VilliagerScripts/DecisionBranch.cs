using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBranch : DecisionNode
{
    public DecisionNode trueNode;
    public DecisionNode falseNode;
    public Func<bool> decisionFunction;

    public override void MakeDecision()
    {
        if (decisionFunction())
        {
            trueNode.MakeDecision();
        }
        else
        {
            falseNode.MakeDecision();
        }
    }
}
