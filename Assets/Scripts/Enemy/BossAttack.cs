using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public ObstacleFactory obstacleFactory;
    public float attackInterval = 5f;
    public float circleRadius = 10f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = randomDirection * circleRadius;

            obstacleFactory.CreateObstacle(ObstacleType.Diamond, spawnPosition);
        }
    }
}