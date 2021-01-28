using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> enemySpawners;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawners = new List<Transform>();
        foreach (Transform child in transform)
        {
            enemySpawners.Add(child);
        }
        InvokeRepeating("SpawnEnemy", 1f, 5f);
    }

    void SpawnEnemy()
    {
        int enemySpawnerIndex = Random.Range(0, enemySpawners.Count);
        Transform enemySpawner = enemySpawners[enemySpawnerIndex];
        Instantiate(enemyPrefab, enemySpawner.position, enemySpawner.rotation);
    }
}
