using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Spear : Goal_Base
{
    float MinDistanceToAttack = 8f;
    float DistanceToStopAttack = 7f;
    float CurrentPriority = 0f;
    int attackPriority = 65;

    public override void OnTickGoal()
    {


        distance = Vector2.Distance(Agent.transform.position, player.transform.position);

        CurrentPriority = MinDistanceToAttack < distance ? 0 : attackPriority;

    }
    public override void OnGoalActivated(Action_Base linkedAction)
    {
        base.OnGoalActivated(linkedAction);

        CurrentPriority = attackPriority;
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
        if (Stats.currentHealth < 450 && distance > 4f)
        {
            return true;
        }
        else
        {
            return false;

        }
    }

}
