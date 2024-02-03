using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Base : MonoBehaviour
{
    protected CharacterAgent Agent;
   
    protected Goal_Base LinkedGoal;
    public GameObject player;
    protected PutThisOnPlayer thisPlayer;
    void Awake()
    {
        Agent = GetComponent<CharacterAgent>();
        thisPlayer = GetComponent<PutThisOnPlayer>();
    }

    public virtual List<System.Type> GetSupportedGoals()
    {
        return null;
    }

    public virtual float GetCost()
    {
        return 0f;
    }

    public virtual void OnActivated(Goal_Base linkedGoal)
    {
        LinkedGoal = linkedGoal;
    }

    public virtual void OnDeactivated()
    {
        LinkedGoal = null;
    }

    public virtual void OnTick()
    {

    }
}
