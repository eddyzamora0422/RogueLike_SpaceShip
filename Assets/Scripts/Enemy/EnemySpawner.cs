using UnityEngine;
using UnityEngine.Timeline;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public GameObject enemySwarm;

    public float baseSpawnRate = 2f;
    public float minSpawnRate = 0.3f;
    public float spawnRate;
    float timer;

    public float spawnOffset = 2f;
    public static bool bossTime = false;

    Transform player;
    //Transform boss;
    Camera cam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        //boss = GameObject.FindGameObjectWithTag("Boss")?.transform;
        cam = Camera.main;
    }

    void Update()
    {
        if (player == null) return;

        UpdateSpawnRate();

        timer += Time.deltaTime;
        if (timer >= spawnRate && GameManager.instance.gameTimer < 600f)
        {
            SpawnEnemy();
            timer = 0;
        }else if (!bossTime && GameManager.instance.gameTimer > 599f)
        {
            SpawnBoss();
            bossTime = true;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = GetSpawnPosition();
        float timeGame = GameManager.instance.gameTimer;

        if (timeGame < 120f)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                int cantidad = Random.Range(2, 5);
                for (int i = 0; i < cantidad; i++)
                {
                    Vector3 offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                    Instantiate(enemySwarm, spawnPos + offset, Quaternion.identity);
                }
            }
        }
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

    void UpdateSpawnRate()
    {
        float gameTime = GameManager.instance.gameTimer;

        //cada 120 segundos (2min) reduce el spawnrate
        int intervals = Mathf.FloorToInt(gameTime / 120f);
        float reduction = intervals * 0.3f; // cuánto reduce por intervalo

        spawnRate = Mathf.Max(minSpawnRate, baseSpawnRate - reduction);
    }

    void SpawnBoss()
    {

        Vector3 spawnPos = GetSpawnPosition();
        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }
}