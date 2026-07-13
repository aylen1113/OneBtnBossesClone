using System.Collections;
using UnityEngine;

public class BossProjectileAttack : MonoBehaviour
{
    public ObstacleFactory factory;

    public float attackInterval = 2f;

    public float spawnDistance = 0.8f;

    public int projectileCount = 10;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);

            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * (360f / projectileCount);

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            Vector2 spawnPosition = (Vector2)transform.position + direction * spawnDistance;

            Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);

            GameObject projectile = factory.CreateObstacle( ObstacleType.Projectile, spawnPosition, rotation);

            projectile.GetComponent<EnemyShooting>().Initialize(direction);
        }
    }
}