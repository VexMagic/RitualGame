using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAttack : MonoBehaviour
{
    [SerializeField] private float attackFrequency;
    private float attackTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (AttackTimer())
            Attack();
    }

    protected virtual void Attack() {}

    protected bool AttackTimer()
    {
        if (attackTime < 0)
        {
            attackTime = attackFrequency;
            return true;
        }

        attackTime -= Time.deltaTime;
        return false;
    }
}
