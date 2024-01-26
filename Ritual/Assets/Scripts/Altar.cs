using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private CircleCollider2D altarCol;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Unlock()
    {
        Debug.Log("Unlocked!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.blood >= 200)
                Unlock();
            else
                Debug.Log("NOT ENOUGH BLOOD");
        }

    }

}
