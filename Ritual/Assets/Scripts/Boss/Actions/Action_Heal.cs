using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Heal : Action_Base
{

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Heal) });

    Goal_Heal HealGoal;
  

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
        HealGoal = (Goal_Heal)LinkedGoal;


    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();
      
        HealGoal = null;
    }

    public override void OnTick()
    {
        Agent.Healing();
        // lägg till effekt

    }
}
