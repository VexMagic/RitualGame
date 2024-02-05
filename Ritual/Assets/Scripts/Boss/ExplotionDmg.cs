using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionDmg : MonoBehaviour
{
   
    
    [SerializeField] int damge = 9;

    public bool tickingBomb = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tickingBomb)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ritual"))
            {
                collision.GetComponent<ObjectStats>().TakeDamage(damge);

            }
        }
        

    }
}
