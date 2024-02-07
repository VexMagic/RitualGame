using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal_Idle : Goal_Base
{
    float MinDistanceToHeal = 10f;

    float CurrentPriority = 0f;
    int IdelPrio = 0;
    [SerializeField] GameObject boss;
    float timer = 0f;
    [SerializeField] float bossTime = 30f;
    public override void OnTickGoal()
    {
        boss.SetActive(false);
        timer += Time.deltaTime;


    }
    public override void OnGoalActivated(Action_Base linkedAction)
    {
        base.OnGoalActivated(linkedAction);

        CurrentPriority = IdelPrio;
    }
    public override void OnGoalDeactivated()
    {
        boss.SetActive(true);
        base.OnGoalDeactivated();


    }

    public override int CalculatePriority()
    {

        return Mathf.FloorToInt(CurrentPriority);
    }
    public override bool CanRun()
    {
       
        if (timer < bossTime)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
}
