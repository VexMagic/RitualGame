using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPDrop : MonoBehaviour
{
    //how much xp the player gets
    [SerializeField] private int amount; 
    [SerializeField] private string playerTag;
    [SerializeField] private GameObjectEventSO onPickup;

    public int Amount { get { return amount; }  }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //give player xp
        //inactivate GO in objectpool
        if(collision.CompareTag(playerTag))
        {
            //give player xp
            onPickup.Invoke(this.gameObject);
        }
    }
}
