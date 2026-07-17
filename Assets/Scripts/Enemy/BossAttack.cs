using System.Collections;
using UnityEngine;

public class BossAttack : AttackBase
{
    [SerializeField] private float circleRadius = 10f;

    public override IEnumerator ExecuteAttack()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = randomDirection * circleRadius;

        factory.CreateObstacle(ObstacleType.Diamond, spawnPosition);

        yield return new WaitForSeconds(1f);
    }
}