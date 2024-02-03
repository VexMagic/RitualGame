using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Goal_Chase : Goal_Base
{
    [SerializeField] int ChasePriority = 50;
    [SerializeField] float DistanceToStopChase = 1f;
    int CurrentPriority = 0;
   

    public Vector2 MoveTarget => player != null ? player.transform.position : transform.position;
    public override void OnTickGoal()
    {
        CurrentPriority = 0;

        // player distance or ritual?
        distance = Vector2.Distance(Agent.transform.position, player.transform.position);

        CurrentPriority = distance < DistanceToStopChase ? 0 : ChasePriority;


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
        return true;
    }
}
