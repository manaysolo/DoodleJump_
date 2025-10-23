using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{

    public GameObject platformPrefab;
    public Transform player;

    public float levelWidth = 3f;
    public float minY = 0.5f;
    public float maxY = 1.5f;

    private float spawnY = 0f;  // Y où on va spawn la prochaine plateforme
    private float spawnThreshold = 10f;  // Distance avant de spawn plus de plateformes
    private int platformsPerBatch = 10; // Combien de plateformes à spawn à chaque fois

    void Start()
    {
        // Spawn initiale pour commencer
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Tant que le joueur est proche de la zone de génération, on crée plus de plateformes
        if (player.position.y + spawnThreshold > spawnY)
        {
            for (int i = 0; i < platformsPerBatch; i++)
            {
                SpawnPlatform();
            }
        }
    }

    void SpawnPlatform()
    {
        float spawnX = Random.Range(-levelWidth, levelWidth);
        spawnY += Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
