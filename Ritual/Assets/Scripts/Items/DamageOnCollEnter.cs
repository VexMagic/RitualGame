using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollEnter : MonoBehaviour
{
    [SerializeField] private string tagToDamage;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToDamage))
            DealDamage(collision.gameObject);
    }

    private void DealDamage(GameObject go)
    {
        Debug.Log("Damaged enemy");
        go.GetComponent<VillagerStats>().TakeDamage(damage);
    }
}
