using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 1f; // The interval between spawns

    void Start()
    {
        // Start the SpawnEnemy coroutine
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Instantiate the enemy prefab at this GameObject's position
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}