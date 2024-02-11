using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Action_Charge : Action_Base
{

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Chase) });

    Goal_Chase ChaseGoal;
    float movmentSpeed = 90f;
    float cost = 2f;
    float timer = 0.1f;
    float chargeTime = 4.5f;
    bool charing = false;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {

      
        return cost;
    }

    public override void OnActivated(Goal_Base linkedGoal)
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);
        if (distance > 8)
        {
            charing = true;

        }
        else
        {


            cost = 2f;
        }

        if (charing)
        {
            timer += Time.deltaTime;
            if (timer > chargeTime)
            {
                cost = 0;
            }
            else
            {

                cost = 2f;
                timer = 0;
                charing = false;
            }

        }
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
