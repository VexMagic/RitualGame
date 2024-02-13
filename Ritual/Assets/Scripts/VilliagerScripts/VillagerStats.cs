using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Events")]
    [SerializeField] private GameObjectEventSO onDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        onDeath.Invoke(this.gameObject);
    }

    public void ResetEnemy()
    {
        currentHealth = maxHealth;
    }
}
