using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectStats : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] private Slider healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = (float)health / (float)maxHealth;
        if (health < 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Debug.Log("Death");
        SceneManager.LoadScene(1);
    }
}
