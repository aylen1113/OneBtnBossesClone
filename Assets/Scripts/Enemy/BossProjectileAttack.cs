using UnityEngine;

public class BossProjectileAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform bossPosition;
    public float projectileSpeed = 10f;

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, bossPosition.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * projectileSpeed;
    }
}
