using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollEnter : MonoBehaviour
{
    [SerializeField] private string tagToDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToDamage))
            DealDamage();
    }

    private void DealDamage()
    {
        Debug.Log("damage");
    }
}
