using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAgent : MonoBehaviour
{
    [SerializeField] float movmentSpeed = 2.7f;
    [SerializeField] GameObject projectileVillagerPrefab;
    public Transform target; 
    float rotationSpeed = 2000f;

    [SerializeField] float activationSwordDelay = 0.8f; 

    private float timer = 0f;
   
    float attackTime = 6f;

    public float bombDelay = 1f;

    private float bombTimer = 0f;

    float bombTime = 1f;

    private float healTimer = 0f;
    [SerializeField] int damgeExplotion = 9;
    [SerializeField] int healPerSec = 3;
    float hTime = 1f;

    public GameObject redObjectToActivate;
    public GameObject explotionToActivate;
    public HealthBar healthBar;

    float agentHealth = 50;
    [SerializeField] float explotionRadius = 4f;
    [SerializeField] float projectileSpeed = 8f;
    [SerializeField] float shootCooldown = 1.0f;
    private float timeSinceLastShot = 0f;

    [SerializeField] SwordDmg swordDmg;
    VillagerStats stats;
 

    public  void MoveTo(Vector2 destination , float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
    public void MoveAway(Vector2 destination )
    {
        transform.position = -Vector2.MoveTowards(transform.position, destination, movmentSpeed * Time.deltaTime);
    }
    private void Awake()
    {
        stats = GetComponent<VillagerStats>();
    }

    private void Update()
    {
        healthBar.UpdateHealth(stats.currentHealth);
       
    }
    public void SwordAttack()
    {
        
        redObjectToActivate.SetActive(true);


        timer += Time.deltaTime;

        if (timer >= activationSwordDelay)
        {
            swordDmg.AttackTargets();
            float rotationAngle = rotationSpeed * Time.deltaTime;



            transform.RotateAround(target.position, Vector3.forward, rotationAngle);
            if (attackTime < timer)
            {

                timer = 0f;

            }
        }


    }
    public void DeActivateRed()
    {
        redObjectToActivate.SetActive(false);
      
    }

    public void Explode(GameObject player)
    {
        explotionToActivate.SetActive(true);

        bombTimer += Time.deltaTime;

        if (bombTimer >= activationSwordDelay)
        {
            float  distance = Vector2.Distance(this.transform.position, player.transform.position);
            if (distance < explotionRadius)
            {
                player.GetComponent<ObjectStats>().TakeDamage(damgeExplotion);
            }
          
        }

        

        
    }
    public void DeActivateExplode()
    {
        explotionToActivate.SetActive(false);
        bombTimer = 0f;
    }
    //public void HealthBarUpdate(int Health)
    //{
       
    //    healthBar.health = Health;
    //}

    public void Healing() 
    {
        healTimer += Time.deltaTime;

        if (healTimer >= hTime)
        {

            stats.currentHealth += healPerSec;
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

        //rotate projectiles towards vel
        Vector2 v = projectileRb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


}
