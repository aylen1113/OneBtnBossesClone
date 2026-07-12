using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public ObjectPool projectilePool;
    public float shootingInterval = 2f;
    public float projectileSpeed = 5f;

    private float nextShotTime;

    void Update()
    {

        if (Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + shootingInterval;
        }
    }

    void Shoot()
    {
        GameObject projectile = projectilePool.GetObject();

        projectile.transform.position = transform.position;
        projectile.transform.rotation = Quaternion.identity;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * projectileSpeed;
    }
}