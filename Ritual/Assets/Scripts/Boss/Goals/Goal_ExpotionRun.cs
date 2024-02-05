using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_ExpotionRun : Goal_Base
{

    float MinDistanceToAttack = 4f;
    float DistanceToStopAttack = 7f;
    float CurrentPriority = 0f;
    int Priority = 65;
    int restart = 75;
    float PriorityBuildRate = 3f;
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
        
        return Mathf.FloorToInt(CurrentPriority);
    }
    public override bool CanRun()
    {
        if(Stats.currentHealth < 800)
        {
            return true;
        }
        else
        {
            return true;
        }
    }
}
