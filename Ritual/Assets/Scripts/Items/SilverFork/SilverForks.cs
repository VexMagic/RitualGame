using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverForks : Attack
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform rotationCenter;

    [Header("Forks")]
    [SerializeField] private GameObject fork;
    [SerializeField] private int numForks;
    [SerializeField] private float distance;
    private List<GameObject> forks;

    private void Start()
    {
        forks = new List<GameObject>();
        SpawnForks();
        InactivateForks();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        activateEvent.Action += ActivateForks;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        activateEvent.Action -= ActivateForks;
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    private void Update()
    {
        if(!AttackActive)
            return;

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
        forks.Add(newFork);
    }

    private Vector3 CalculateSpawnPosition(float rotAngle)
    {
        return new Vector3(Mathf.Cos(Mathf.Deg2Rad * rotAngle) * distance, Mathf.Sin(Mathf.Deg2Rad * rotAngle) * distance, 0);
    }

    private void ActivateForks()
    {
        foreach(GameObject fork in forks)
        {
            fork.SetActive(true);
        }
    }

    private void InactivateForks()
    {
        foreach (GameObject fork in forks)
        {
            fork.SetActive(false);
        }
    }
}
