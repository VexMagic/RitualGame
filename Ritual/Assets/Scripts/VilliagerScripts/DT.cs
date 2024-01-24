using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DT
{
    public DecisionNode root;

    public DT(DecisionNode root)
    {
        this.root = root;
    }

    public void MakeDecision()
    {
        root.MakeDecision();
    }
}
