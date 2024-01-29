using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    //Determines if an xp sohuld drop, finds out where and serves as communication center between the object pool and enemies
    public static XPManager instance;
    private ObjectPool objectPool;
    private List<GameObject> objects;

    // get position
    //spawn xp
    //remove xp
    //action to inform this that enemy has died


    private void OnEnable()
    {
        XPEvent.OnXPPickUp += RemoveXP;
        XPEvent.OnEnemyDied += SpawnXP;
    }

    private void OnDisable()
    {
        XPEvent.OnXPPickUp -= RemoveXP;
        XPEvent.OnEnemyDied -= SpawnXP;
    }

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        objects = new List<GameObject>();
    }



    private void SpawnXP(Vector3 position)
    {
        GameObject enemy = objectPool.GetPooledObject();

        if (enemy != null)
        {
            enemy.transform.position = position;
            enemy.SetActive(true);
        }
        else
            Debug.Log("Failed to spawn xp");
    }

    public void RemoveXP(GameObject o)
    {
        //remove item from list
        o.SetActive(false);
        objects.Remove(o);
    }
}
