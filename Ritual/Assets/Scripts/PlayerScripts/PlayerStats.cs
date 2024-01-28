using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public int blood; //should move this to a seperated script "PlayerStats" or something
    public int health;
    public int maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Villager")
        {
            health--;
            healthBar.fillAmount = (float)health / (float)maxHealth;
        }
    }
}
