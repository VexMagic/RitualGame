using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverForks : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform rotationCenter;

    [Header("Forks")]
    [SerializeField] private GameObject fork;
    [SerializeField] private int numForks;
    [SerializeField] private float distance;

    private void Start()
    {
        SpawnForks();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    private void Update()
    {
        Rotate();
    }

    private float CalculateForkPositions()
    {
        float rotIncrement = 360 / numForks;
        return rotIncrement;
    }

    private void SpawnForks()
    {
        float rotIncrement = CalculateForkPositions();
        float rot = 0;
        for (int i = 0; i < numForks; i++)
        {
            SpawnFork(rot);
            rot += rotIncrement;
        }
    }

    private void SpawnFork(float rot)
    {
        GameObject newFork = Instantiate(fork, transform);
        newFork.transform.position = transform.position + CalculateSpawnPosition(rot);
    }

    private Vector3 CalculateSpawnPosition(float rotAngle)
    {
        return new Vector3(Mathf.Cos(Mathf.Deg2Rad * rotAngle) * distance, Mathf.Sin(Mathf.Deg2Rad * rotAngle) * distance, 0);
    }
}
