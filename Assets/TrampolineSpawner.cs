using UnityEngine;

public class TrampolineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject trampolinePrefab;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float bounceForce = 20f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTrampoline();
            timer = 0f;
        }
    }

    private void SpawnTrampoline()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        if (platforms.Length == 0) return;

        GameObject platform = platforms[Random.Range(0, platforms.Length)];

        Vector3 spawnPos = platform.transform.position;
        spawnPos.y += 0.5f;  // Ajuste selon ta plateforme

        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos, 0.5f);
        foreach (var col in colliders)
        {
            if (col.CompareTag("Trampoline"))
                return; // Pas de spawn si trampoline proche
        }

        Instantiate(trampolinePrefab, spawnPos, Quaternion.identity);
    }


}
