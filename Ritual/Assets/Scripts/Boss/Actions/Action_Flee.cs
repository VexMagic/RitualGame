using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Action_Flee : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Flee) });

    Goal_Flee FleeGoal;
    float movmentSpeed = 6f;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnActivated(Goal_Base linkedGoal)
    {
        base.OnActivated(linkedGoal);

        // cache the chase goal
        FleeGoal = (Goal_Flee)LinkedGoal;

        Agent.MoveTo(FleeGoal.MoveTarget, movmentSpeed);
        // transform.position = Vector2.MoveTowards(transform.position, thisPlayer.transform.position, movmentSpeed * Time.deltaTime);

    }

    public override void OnDeactivated()
    {

        base.OnDeactivated();

        FleeGoal = null;
    }

    public override void OnTick()
    {
        Agent.MoveAway(FleeGoal.MoveTarget);
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movmentSpeed * Time.deltaTime);
    }
}
