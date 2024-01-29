using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPDrop : MonoBehaviour
{
    //how much xp the player gets
    [SerializeField] private int amount; 
    [SerializeField] private string playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //give player xp
        //inactivate GO in objectpool
        if(collision.CompareTag(playerTag))
        {
            //give player xp
            XPEvent.OnXPPickUp.Invoke(this.gameObject);
        }
    }
}
