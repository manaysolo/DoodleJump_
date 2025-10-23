using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;  
    [SerializeField] private Transform playerTransform;  

    [SerializeField] private float spawnRangeX = 8f;  
    [SerializeField] private float spawnHeightOffset = 10f; 

    private float nextSpawnHeight = 20f;  
    private int enemiesToSpawn = 1;  

    void Update()
    {
       
        if (playerTransform.position.y + spawnHeightOffset > nextSpawnHeight)
        {
            SpawnEnemies(enemiesToSpawn);

            nextSpawnHeight += 20f;
            enemiesToSpawn +=1;   
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float spawnY = nextSpawnHeight + Random.Range(-5f, 5f);

            Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
