using System.Collections;
using UnityEngine;

public class Spawnheal : MonoBehaviour
{
    public GameObject healthKitPrefab; // The health kit prefab
    public float spawnInterval = 5f; // The interval between spawns
    public float spawnRadius = 5f; // The radius around the spawner where health kits can spawn

    private void Start()
    {
        // Start the SpawnHealthKits coroutine
        StartCoroutine(SpawnHealthKits());
    }

    private IEnumerator SpawnHealthKits()
    {
        while (true)
        {
            // Wait for the spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Use the spawner's position as the spawn position

            // Spawn a new health kit
            Instantiate(healthKitPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}