using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    //Determines if an xp sohuld drop, finds out where and serves as communication center between the object pool and enemies
    //currently every enemy kill spawns a xp drop
    public static XPManager instance;
    private ObjectPool objectPool;
    private List<GameObject> objects;

    [Header("Events")]
    [SerializeField] private GameObjectEventSO spawnXp;
    [SerializeField] private GameObjectEventSO removeXP;


    private void OnEnable()
    {
        spawnXp.Action += SpawnXP;
        removeXP.Action += RemoveXP;
    }

    private void OnDisable()
    {
        spawnXp.Action -= SpawnXP;
        removeXP.Action -= RemoveXP;
    }

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        objects = new List<GameObject>();
    }



    private void SpawnXP(GameObject go)
    {
        GameObject enemy = objectPool.GetPooledObject();

        if (enemy != null)
        {
            enemy.transform.position = go.transform.position;
            enemy.SetActive(true);
        }
        else
            Debug.Log("Failed to spawn xp");
    }

    public void RemoveXP(GameObject go)
    {
        //remove item from list
        go.SetActive(false);
        objects.Remove(go);
    }
}
