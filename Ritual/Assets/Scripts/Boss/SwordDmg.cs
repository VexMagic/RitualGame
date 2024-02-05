using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDmg : MonoBehaviour
{
 
    [SerializeField] int damage = 1;
    [SerializeField] float attacksPerSecond = 1.5f;
    private float attackTimer;
    private List<ObjectStats> attackingTargets = new List<ObjectStats>();
 
    public bool active = false;
    private void Update()
    {
        if (active)
        {

            AttackTargets();
        }
    }
    public void AttackTargets()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attacksPerSecond && attackingTargets.Count != 0)
        {
            attackTimer = 0;

            foreach (var target in attackingTargets)
            {
                target.TakeDamage(damage);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name);

        if (other.CompareTag("Player") || other.CompareTag("Ritual"))
        {
            attackingTargets.Add(other.GetComponent<ObjectStats>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name);

        if (other.CompareTag("Player") || other.CompareTag("Ritual"))
        {
            if (attackingTargets.Contains(other.GetComponent<ObjectStats>()))
            {
                attackingTargets.Remove(other.GetComponent<ObjectStats>());
            }
        }
    }
}
