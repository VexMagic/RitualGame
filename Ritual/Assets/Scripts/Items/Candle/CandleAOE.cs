using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleAOE : DamagingAOE
{
    [SerializeField] private float duration;
    private float timeAlive;

    private void Update()
    {
        if (duration > 0)
            IncrementTTL();
    }
    private void IncrementTTL()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= duration)
            OnTTLEnd();
    }

    protected virtual void OnTTLEnd()
    {
        Destroy(gameObject);
    }
}
