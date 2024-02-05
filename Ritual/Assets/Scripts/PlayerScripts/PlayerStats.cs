using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : ObjectStats
{
    public int blood; //should move this to a seperated script "PlayerStats" or something

    [SerializeField] private GameObjectEventSO OnXPIncrease;

    private void OnEnable()
    {
        OnXPIncrease.Action += IncreaseXP;
    }

    private void OnDisable()
    {
        OnXPIncrease.Action -= IncreaseXP;
    }

    private void IncreaseXP(GameObject go)
    {
         blood += go.GetComponent<XPDrop>().Amount;
    }
}
