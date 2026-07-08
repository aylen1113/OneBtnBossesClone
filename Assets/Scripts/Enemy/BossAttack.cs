using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float attackInterval = 5f;
    public float circleRadius = 10f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            SpawnRandomObstacle();
            timer = 0;
        }
    }

    void SpawnRandomObstacle()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = randomDirection * circleRadius;
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.SetActive(true);
    }
}