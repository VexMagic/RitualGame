using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Run : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_ExpotionRun) });

    Goal_ExpotionRun RunGoal;
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
        RunGoal = (Goal_ExpotionRun)LinkedGoal;

        Agent.Explode();
        // transform.position = Vector2.MoveTowards(transform.position, thisPlayer.transform.position, movmentSpeed * Time.deltaTime);

    }

    public override void OnDeactivated()
    {

        base.OnDeactivated();
        Agent.DeActivateExplode();
        RunGoal = null;
    }

    public override void OnTick()
    {
        Agent.Explode();
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movmentSpeed * Time.deltaTime);
    }
}
