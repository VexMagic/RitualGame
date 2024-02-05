using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Spear : Action_Base
{

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Spear) });
    Goal_Spear attackGoal;
    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        // lägg till
        float distance = Vector2.Distance(player.transform.position, this.transform.position);

        return 0f;
    }

    public override void OnActivated(Goal_Base linkedGoal)
    {
        base.OnActivated(linkedGoal);
        attackGoal = (Goal_Spear)LinkedGoal;
    }
    public override void OnDeactivated()
    {

        base.OnDeactivated();
        
        attackGoal = null;
    }

    public override void OnTick()
    {
        Agent.Shoot(player);
    }
}
