using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float health;
    // Funktion för att uppdatera hälsomätaren med en given värde (0.0 till 1.0).
   
    public void UpdateHealth(float healthPercentage)
    {
     
        healthSlider.value = healthPercentage;
    }
}
