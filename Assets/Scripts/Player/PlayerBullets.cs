using UnityEngine;

public class PlayersBullets : MonoBehaviour
{
    public Transform enemy;
    public ObjectPool bulletPool;
    public float rotationSpeed = 50f;   
    public float bulletSpeed = 10f;     
    public float fireRate = 1f;         

    private float fireTimer;

    void Update()
    {
       
        if (enemy != null)
        {
            transform.RotateAround(enemy.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        // Temporizador de disparo automático
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    void FireBullet()
    {
        if (enemy != null)
        {
            GameObject bullet = bulletPool.GetObject();

            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Vector2 direction = (enemy.position - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }
}




