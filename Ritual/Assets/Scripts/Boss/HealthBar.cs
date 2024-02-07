using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
   // public float health;
    // (0.0 to 1.0).
   [SerializeField] VillagerStats stats;
   
    public void UpdateHealth(float healthPercentage)
    {
     
        healthSlider.value = healthPercentage/ stats.maxHealth;
    }
}
