using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float timeToLive;
    [SerializeField] private bool destoryOnCOll;
    [SerializeField] private string tagToDamage;
    private Vector3 firingDir;
    private bool fired;
    private float timeAlive;


    // Start is called before the first frame update
    void Start()
    {
        //fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            Move();
            IncrementTTL();
        }
    }

    public void Initiate(Vector3 spawnPoint, Vector3 firingDir)
    {
        transform.position = spawnPoint;
        this.firingDir = firingDir;

    }

    public void Fire()
    {
        fired = true;
    }

    private void Move()
    {
        transform.position += firingDir * speed * Time.deltaTime;
    }

    private void IncrementTTL()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToLive)
            OnTTLEnd();
    }

    protected virtual void OnTTLEnd()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToDamage))
        {
            collision.transform.GetComponent<VillagerStats>().TakeDamage(damage);
            if (destoryOnCOll)
                Destroy(gameObject);
        }
    }

}
