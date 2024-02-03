using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ExpotionRun : Goal_Base
{

    float MinDistanceToAttack = 4f;
    float DistanceToStopAttack = 7f;
    float CurrentPriority = 0f;
    int Priority = 65;
    int restart = 70;
    [SerializeField] float PriorityBuildRate = 1f;
    public override void OnTickGoal()
    {
        CurrentPriority += PriorityBuildRate * Time.deltaTime;
        //distance = Vector2.Distance(Agent.transform.position, player.transform.position);

        if(CurrentPriority > restart)
        {
            CurrentPriority = 0f;
        }

        //CurrentPriority = MinDistanceToAttack < distance ? 0 : Priority;

    }
    public override void OnGoalActivated(Action_Base linkedAction)
    {
        base.OnGoalActivated(linkedAction);

        CurrentPriority = Priority;
    }
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();


    }

    public override int CalculatePriority()
    {
        // l�gg till om fienden �r l�ngt borta
        return Mathf.FloorToInt(CurrentPriority);
    }
    public override bool CanRun()
    {


        return true;
    }
}
