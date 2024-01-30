
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerProjectile : MonoBehaviour
{
    float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 1.5f;

    void Start()
    {

        //Rigidbody2D projectileRb = GetComponent<Rigidbody2D>();


        //projectileRb.velocity = new Vector2(projectileSpeed, 0f);


        Destroy(gameObject, projectileLifetime);
    }
}
