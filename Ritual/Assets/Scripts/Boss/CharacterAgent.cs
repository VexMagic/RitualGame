using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAgent : MonoBehaviour
{
    float movmentSpeed = 6f;

    public Transform target; 
    float rotationSpeed = 2000f;

    public float activationDelay = 1f; 

    private float timer = 0f;
    private bool timerStarted = false;
    float attackTime = 6f;

    public GameObject redObjectToActivate;
    public GameObject explotionToActivate;


    public  void MoveTo(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, movmentSpeed * Time.deltaTime);
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
}
