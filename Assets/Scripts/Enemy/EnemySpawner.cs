using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 2f;
    float timer;

    public float spawnOffset = 2f;

    Transform player;
    Camera cam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        cam = Camera.main;
    }

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = GetSpawnPosition();

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    Vector3 GetSpawnPosition()
    {
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        int side = Random.Range(0, 4);

        Vector3 spawnPos = player.position;

        switch (side)
        {
            case 0: // arriba
                spawnPos += new Vector3(Random.Range(-width, width), height + spawnOffset, 0);
                break;

            case 1: // abajo
                spawnPos += new Vector3(Random.Range(-width, width), -height - spawnOffset, 0);
                break;

            case 2: // izquierda
                spawnPos += new Vector3(-width - spawnOffset, Random.Range(-height, height), 0);
                break;

            case 3: // derecha
                spawnPos += new Vector3(width + spawnOffset, Random.Range(-height, height), 0);
                break;
        }

        return spawnPos;
    }
}