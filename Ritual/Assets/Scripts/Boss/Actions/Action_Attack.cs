using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Action_Attack : Action_Base
{
    

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Attack) });
    Goal_Attack attackGoal;
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
        attackGoal = (Goal_Attack)LinkedGoal;
    }
    public override void OnDeactivated()
    {
     
        base.OnDeactivated();
        Agent.DeActivateRed();
        attackGoal = null;
    }

    public override void OnTick()
    {
        Agent.SwordAttack();
    }
}
