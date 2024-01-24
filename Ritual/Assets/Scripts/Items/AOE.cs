using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{

    [SerializeField] private float tickDamage;
    [SerializeField] private float tickFrequency;
    //duration 0 = doesn't stop
    [SerializeField] private float duration;
    [SerializeField] private string tagToUseEffectOn;
    private float timer;
    private float timeAlive;
    private List<GameObject> gameObjects;

    private void Start()
    {
        gameObjects = new List<GameObject>();
    }

    void Update()
    {
        if (TickTimer())
            UseEffect();

        if (duration > 0)
            IncrementTTL();
    }



    internal void Initiate(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }

    protected virtual void Effect(GameObject obj) { }


    private void UseEffect()
    {
        foreach (GameObject obj in gameObjects)
        {
            Effect(obj);
        }
    }

    protected bool TickTimer()
    {
        if (timer < 0)
        {
            timer = tickFrequency;
            return true;
        }

        timer -= Time.deltaTime;
        return false;
    }

    private void IncrementTTL()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= duration)
            OnTTLEnd();
    }

    protected virtual void OnTTLEnd()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToUseEffectOn))
        {
            Debug.Log(collision.name + " entered");
            gameObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToUseEffectOn))
        {
            Debug.Log(collision.name + " exited");
            gameObjects.Remove(collision.gameObject);
        }
    }
}
