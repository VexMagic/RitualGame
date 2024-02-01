using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private SpriteRenderer water;
    
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
        water.color = Color.red;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.blood >= 200)
                Unlock();
            else
                Debug.Log("NOT ENOUGH BLOOD");
        }
    }

}
