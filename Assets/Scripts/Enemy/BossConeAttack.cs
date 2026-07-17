using System.Collections;
using UnityEngine;

public class BossConeAttack : AttackBase
{
    [SerializeField] private float circleRadius = 6f;

    public override IEnumerator ExecuteAttack()
    {
        SpawnCone();

        yield return new WaitForSeconds(2f);
    }

    private void SpawnCone()
    {
        float angle = Random.Range(0f, 360f);

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        Vector2 spawnPosition = direction * circleRadius;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, -direction);

        factory.CreateObstacle(ObstacleType.Cone, spawnPosition, rotation);
    }
}
