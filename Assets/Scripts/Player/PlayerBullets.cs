using UnityEngine;

public class PlayersBullets : MonoBehaviour
{
    public Transform enemy;             // Referencia al enemigo en el centro
    public GameObject bulletPrefab;     // Prefab de la bala
    public float rotationSpeed = 50f;   // Velocidad de movimiento circular
    public float bulletSpeed = 10f;     // Velocidad de la bala
    public float fireRate = 1f;         // Intervalo de disparo

    private float fireTimer;

    void Update()
    {
        // Movimiento circular alrededor del enemigo
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
        if (enemy != null && bulletPrefab != null)
        {
            // Crear la bala
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Calcular dirección hacia el enemigo
            Vector2 directionToEnemy = (enemy.position - transform.position).normalized;

            // Ajustar la rotación de la bala para que apunte al enemigo
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Asignar velocidad a la bala
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = directionToEnemy * bulletSpeed;
        }
    }
}


//[SerializeField] float rotationSpeed = 200f;  // Ajusta según sea necesario
//[SerializeField] float bulletSpeed = 5f;      // Ajusta según sea necesario
//[SerializeField] Rigidbody2D _rb;
//Transform target;

//void Awake()
//{
//    target = GameObject.FindGameObjectWithTag("Enemy")?.transform;
//}

//private void FixedUpdate()
//{
//    if (target != null)
//    {
//        ChaseTarget();
//    }
//    else
//    {
//        _rb.velocity = transform.right * bulletSpeed;  // Continúa en la dirección actual si no hay objetivo
//    }
//}

//private void ChaseTarget()
//{
//    Vector2 direction = (target.position - transform.position).normalized;
//    float rotationAmount = Vector3.Cross(direction, transform.right).z;

//    _rb.angularVelocity = -rotationAmount * rotationSpeed;
//    _rb.velocity = transform.right * bulletSpeed;

