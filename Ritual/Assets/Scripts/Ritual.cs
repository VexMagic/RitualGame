using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ritual : MonoBehaviour
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

    }
}
