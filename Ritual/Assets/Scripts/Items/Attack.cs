using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected EventSO activateEvent;
    [SerializeField] private bool attackActive;
    [SerializeField] private bool startActive;
    protected bool AttackActive { get { return attackActive; } }

    protected virtual void OnEnable()
    {
        if (!startActive)
            activateEvent.Action += ActivateAttack;
    }

    protected virtual void OnDisable()
    {
        if (!startActive)
            activateEvent.Action -= ActivateAttack;
    }

    protected virtual void Start()
    {
        if (startActive)
            attackActive = true;
    }

    private void ActivateAttack()
    {
        attackActive = true;
    }
}
