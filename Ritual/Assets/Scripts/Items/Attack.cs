using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected EventSO activateEvent;
    [SerializeField] private bool attackActive;
    protected bool AttackActive {  get { return attackActive; } }

    protected virtual void OnEnable()
    {
        activateEvent.Action += ActivateAttack;
    }

    protected virtual void OnDisable()
    {
        activateEvent.Action -= ActivateAttack;
    }

    protected virtual void Start()
    {
        attackActive = false;
    }

    private void ActivateAttack()
    {
        attackActive = true;
    }
}
