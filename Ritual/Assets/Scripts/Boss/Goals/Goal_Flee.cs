using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Flee : Goal_Base
{
    [SerializeField] int FleePrio = 61;
    [SerializeField] float DistanceToStopChase = 1f;
    int CurrentPriority = 0;


    public Vector2 MoveTarget => player != null ? player.transform.position : transform.position;
    public override void OnTickGoal()
    {
        CurrentPriority = 0;

        // player distance or ritual?
        distance = Vector2.Distance(Agent.transform.position, player.transform.position);

        CurrentPriority = distance < DistanceToStopChase ? 0 : FleePrio - (int)distance;


    }
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();


    }

    public override int CalculatePriority()
    {
        return CurrentPriority;
    }
    public override bool CanRun()
    {
        if(Agent.agentHealth < 20)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
