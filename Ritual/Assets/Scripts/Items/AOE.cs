using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{

    [SerializeField] protected int tickDamage;
    [SerializeField] private float tickFrequency;
    //duration 0 = doesn't stop
    [SerializeField] private string tagToUseEffectOn;
    private float timer;
    private List<GameObject> gameObjects;

    private void Start()
    {
        Debug.Log("Start");
        gameObjects = new List<GameObject>();
    }

    protected virtual void Update()
    {
        if (TickTimer())
            UseEffect();
    }



    internal void Initiate(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
    }

    protected virtual void Effect(GameObject obj) { }


    private void UseEffect()
    {
        if (gameObjects.Count <= 0)
            return;

        for(int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i] != null)
                Effect(gameObjects[i]);
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
