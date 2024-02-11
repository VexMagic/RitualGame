using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Chase) });

    Goal_Chase ChaseGoal;
    float movmentSpeed = 4.2f;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        return 1f;
    }

    public override void OnActivated(Goal_Base linkedGoal)
    {
        base.OnActivated(linkedGoal);

        // cache the chase goal
        ChaseGoal = (Goal_Chase)LinkedGoal;

        Agent.MoveTo(ChaseGoal.MoveTarget, movmentSpeed);
        // transform.position = Vector2.MoveTowards(transform.position, thisPlayer.transform.position, movmentSpeed * Time.deltaTime);

    }

    public override void OnDeactivated()
    {
      
        base.OnDeactivated();

        ChaseGoal = null;
    }

    public override void OnTick()
    {
        Agent.MoveTo(ChaseGoal.MoveTarget, movmentSpeed);
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movmentSpeed * Time.deltaTime);
    }
}
