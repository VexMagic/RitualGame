using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Heal : Goal_Base
{
    float MinDistanceToHeal = 10f;
   
    float CurrentPriority = 0f;
    int healPriority = 85;

    public override void OnTickGoal()
    {


        distance = Vector2.Distance(Agent.transform.position, player.transform.position);

        CurrentPriority = MinDistanceToHeal < distance ? 0 : healPriority - (Stats.currentHealth/15);

    }
    public override void OnGoalActivated(Action_Base linkedAction)
    {
        base.OnGoalActivated(linkedAction);

        CurrentPriority = healPriority;
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
        distance = Vector2.Distance(Agent.transform.position, player.transform.position);
        if (Stats.currentHealth < 800 && distance > 8f)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
}
