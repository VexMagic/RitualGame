using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Goal_Attack : Goal_Base
{

    float MinDistanceToAttack = 4f;
    float DistanceToStopAttack = 7f;
    float CurrentPriority = 0f;
    int attackPriority = 60;
   
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

    public override int CalculatePriority()
    {
        // lägg till om fienden är långt borta
        return Mathf.FloorToInt(CurrentPriority);
    }
    public override bool CanRun()
    {

       
        return true;
    }
}
