using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs;

    public float spawnArea_X = 5f;
    public float spawnArea_Y = 10f;
    public float spawnArea_Z = 5f;

    void Start()
    {
        StartCoroutine(SpawnRandomPrefabs());
    }

    IEnumerator SpawnRandomPrefabs()
    {
        for (int i = 0; i < 30; i++)
        {
            float randomX = Random.Range(-spawnArea_X, spawnArea_X);
            float randomY = Random.Range(0f, spawnArea_Y);
            float randomZ = Random.Range(-spawnArea_Z, spawnArea_Z);

            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            int randomPrefabIndex = Random.Range(0, prefabs.Length); // ·£´ýÀ¸·Î ÇÁ¸®ÆÕ ÀÎµ¦½º ¼±ÅÃ
            GameObject prefabToSpawn = prefabs[randomPrefabIndex];

            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(15f);
        }
    }
}
