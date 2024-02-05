using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private SpriteRenderer water;
    [SerializeField] private int cost;
    [Header("Events")]
    [SerializeField] private EventSO unlockEvent;

    void Unlock()
    {
        Debug.Log("Unlocked!");
        water.color = Color.red;
        unlockEvent.Invoke();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.blood >= cost)
                Unlock();
            else
                Debug.Log("NOT ENOUGH BLOOD");
        }
    }

}
