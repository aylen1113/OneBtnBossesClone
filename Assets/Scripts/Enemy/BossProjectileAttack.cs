using UnityEngine;
using System.Collections;


public class BossProjectileAttack : AttackBase
{
    [SerializeField] private float spawnDistance = 0.8f;
    [SerializeField] private int projectileCount = 10;

    public override IEnumerator ExecuteAttack()
    {
        SpawnProjectiles();

        yield return new WaitForSeconds(2f);
    }

    private void SpawnProjectiles()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * (360f / projectileCount);

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector2 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

            Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);

            GameObject projectile = factory.CreateObstacle(ObstacleType.Projectile, spawnPosition, rotation);

            projectile.GetComponent<EnemyShooting>().Initialize(direction);
        }
    }
}