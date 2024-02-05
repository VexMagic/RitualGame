using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IGoal
{
    int CalculatePriority();
    bool CanRun();
    void OnTickGoal();
    void OnGoalActivated(Action_Base linkedAction);
    void OnGoalDeactivated();
}
public class Goal_Base : MonoBehaviour, IGoal
{
    protected CharacterAgent Agent;

    public  GameObject player;

    protected PutThisOnPlayer thisPlayer;

    protected Action_Base LinkedAction;

    public float distance;
    void Awake()
    {
        Agent = GetComponent<CharacterAgent>();
        thisPlayer = GetComponent<PutThisOnPlayer>();
    }

    void Start()
    {
        
    }
    void Update()
    {
       

    }

    public virtual int CalculatePriority()
    {
        return -1;
    }
    public virtual bool CanRun()
    {
        return false;
    }


    public virtual void OnTickGoal()
    {

    }

    public virtual void OnGoalActivated(Action_Base linkedAction)
    {
        LinkedAction = linkedAction;

    }

    public virtual void OnGoalDeactivated()
    {
        LinkedAction = null;
    }
}
