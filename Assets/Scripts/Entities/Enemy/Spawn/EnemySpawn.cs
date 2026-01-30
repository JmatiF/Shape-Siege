using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 15f;

    [SerializeField]
    private GameObject[] enemies;

    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (enemies.Length == 0)
            return;

        int index = Random.Range(0, enemies.Length);
        Instantiate(enemies[index], transform.position, Quaternion.identity);
    }
}
