using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAgent : MonoBehaviour
{
    float movmentSpeed = 4f;
    [SerializeField] GameObject projectileVillagerPrefab;
    public Transform target; 
    float rotationSpeed = 2000f;

    public float activationDelay = 1f; 

    private float timer = 0f;
    private bool timerStarted = false;
    float attackTime = 6f;

    private float healTimer = 0f;
   
    float hTime = 1f;

    public GameObject redObjectToActivate;
    public GameObject explotionToActivate;
    public HealthBar healthBar;

    public float agentHealth = 50;

    [SerializeField] float projectileSpeed = 7f;
    [SerializeField] float shootCooldown = 1.5f;
    private float timeSinceLastShot = 0f;
    public  void MoveTo(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, movmentSpeed * Time.deltaTime);
    }
    public void MoveAway(Vector2 destination)
    {
        transform.position = -Vector2.MoveTowards(transform.position, destination, movmentSpeed * Time.deltaTime);
    }
    private void Update()
    {
        healthBar.UpdateHealth(agentHealth/100);
    }
    public void SwordAttack()
    {
        redObjectToActivate.SetActive(true);
        if (!timerStarted)
        {
           
            timer += Time.deltaTime;

            if (timer >= activationDelay)
            {
               
                float rotationAngle =  rotationSpeed * Time.deltaTime;

              
                transform.RotateAround(target.position, Vector3.forward, rotationAngle);
                if(attackTime< timer)
                {
                   
                    timer = 0f;
                   
                }
            }
        }
      
    }
    public void DeActivateRed()
    {
        redObjectToActivate.SetActive(false);
    }

    public void Explode()
    {
        explotionToActivate.SetActive(true);
    }
    public void DeActivateExplode()
    {
        explotionToActivate.SetActive(false);
    }
    public void HealthBarUpdate(int Health)
    {
       
        healthBar.health = Health;
    }

    public void Healing() 
    {
        healTimer += Time.deltaTime;

        if (healTimer >= hTime)
        {

            agentHealth += 1;
            healTimer = 0f;
        }
       
    }
    public void Shoot(GameObject player)
    {
        timeSinceLastShot += Time.deltaTime;


        if (timeSinceLastShot >= shootCooldown)
        {
            ShootProjectile(player);
            timeSinceLastShot = 0f;
        }

    }
    void ShootProjectile(GameObject player)
    {
        GameObject projectile = Instantiate(projectileVillagerPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - transform.position).normalized;


        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;

    }

}
