using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatroll : MonoBehaviour
{
    [SerializeField] float patrolPointReachedThreshold = 0.5f;

    [SerializeField] List<Transform> patrolPoints;
    [SerializeField] float movmentSpeed = 3f;
    int currentPatrolPoint;
    void Update()
    {
        UpdatePatrol();
    }

    private void UpdatePatrol()
    {
        Vector3 vectorToPatrolPoint = patrolPoints[currentPatrolPoint].position - transform.position;

        // reached patrol ponit
        if (vectorToPatrolPoint.magnitude <= patrolPointReachedThreshold)
        {
            //next point 
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
        }
        // move towards the point
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, movmentSpeed * Time.deltaTime);

        // face the patrol point
        transform.LookAt(patrolPoints[currentPatrolPoint], Vector3.up);
    }
}
