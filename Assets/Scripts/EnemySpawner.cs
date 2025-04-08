using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 50;
    public Vector2 spawnAreaMin = new Vector2(10f, -4f);
    public Vector2 spawnAreaMax = new Vector2(15f, 4f);

    private void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x), // posición X
                Random.Range(spawnAreaMin.y, spawnAreaMax.y), // posición Y
                0f
            );

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
