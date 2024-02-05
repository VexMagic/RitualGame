
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VillagerProjectile : MonoBehaviour
{
    float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 1.5f;
    [SerializeField] int damge = 1;

    void Start()
    {

        //Rigidbody2D projectileRb = GetComponent<Rigidbody2D>();


        //projectileRb.velocity = new Vector2(projectileSpeed, 0f);


        Destroy(gameObject, projectileLifetime);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ritual"))
        {
            collision.GetComponent<ObjectStats>().TakeDamage(damge);
            Destroy(gameObject);
        }

    }
}

