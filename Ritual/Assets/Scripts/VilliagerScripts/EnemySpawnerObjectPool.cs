using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerObjectPool : MonoBehaviour
{
    public static EnemySpawnerObjectPool Instance;
    private ObjectPool objectPool;

    public GameObject[] spawnPoints;
    GameObject currentSpawnPoint;

    public List<GameObject> enemies;

    private bool spawnAnEnemy;
    public GameObject player;
    public GameObject[] enemyTypes;
    public float minSpawnTime, maxSpawnTime, spawnRateIncreaseInterval;
    public float spawnTimer;
    public bool canSpawn;

    public int spawnDistanceToPlayer, spawnDistanceToEnemy;
    public int enemyPerSpawn;

    Vector3 randomSpawn;
    public int randomSpawnRangeMin, randomSpawnRangeMax;
    Vector3 trueSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        TriggerWave();

    }

    private void Awake()
    {
        Instance = this;

    }

    public void TriggerWave()
    {
        canSpawn = true;
        spawnTimer = 0;
        Invoke("SpawnEnemy", 0.5f);
    }

    void SpawnEnemy()
    {
        spawnAnEnemy = true;
        currentSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        float timeBetweenSpawns = Random.Range(minSpawnTime, maxSpawnTime);
        trueSpawnPoint = currentSpawnPoint.transform.position - randomSpawn;

        if (canSpawn)
        {
            if (Vector2.Distance(player.transform.position, trueSpawnPoint) < spawnDistanceToPlayer)
            {
                spawnAnEnemy = false;
            }

            if (spawnAnEnemy)
            {           
                for (int i = 0; i < enemyPerSpawn; i++)
                {
                    randomSpawn = new Vector2(Random.Range(randomSpawnRangeMin, randomSpawnRangeMax), Random.Range(randomSpawnRangeMin, randomSpawnRangeMax));

                    GameObject enemy = objectPool.GetPooledObject();
                    if (enemy != null)
                    {
                        enemy.transform.position = randomSpawn;
                        enemy.SetActive(true);
                        enemies.Add(enemy);
                        XPEvent.OnEnemyDied(enemy.transform.position);
                    }
                }
            }
            else
            {
                timeBetweenSpawns = minSpawnTime / 2;
            }

            Invoke("SpawnEnemy", timeBetweenSpawns);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRateIncreaseInterval)
            {
                enemyPerSpawn++;
                spawnTimer = 0;
            }

        }

        //for (int i = 0; i < enemies.Count; i++)
        //{           
        //    //Enemy es = enemies[i].GetComponent<Enemy>();

        //    if (es.health <= 0)
        //    {
        //        Destroy(enemies[i]);
        //        enemies.RemoveAt(i);
        //        i--;
        //    }
        //}

    }
}
