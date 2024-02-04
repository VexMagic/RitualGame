using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float health;
    // Funktion f�r att uppdatera h�lsom�taren med en given v�rde (0.0 till 1.0).
   
    public void UpdateHealth(float healthPercentage)
    {
     
        healthSlider.value = healthPercentage;
    }
}
