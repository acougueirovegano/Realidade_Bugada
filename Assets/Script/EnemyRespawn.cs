using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float coolDown = 30f; // spawn every 30 seconds
    private float timer;
    private Transform player;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= coolDown)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int respawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[respawnPointIndex].position, Quaternion.identity);

        // Optional: flip enemy if spawned on right side
        bool createdOnRight = newEnemy.transform.position.x > player.position.x;
        if (createdOnRight)
        {
            newEnemy.GetComponent<Entity>().Flip();
        }
    }
}