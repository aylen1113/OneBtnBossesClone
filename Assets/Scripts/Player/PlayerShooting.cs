using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform enemy;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shotCooldown = 1f;
    [SerializeField] float shotInitialTime = 0.5f;

    private void Start()
    {
        InvokeRepeating(nameof(ShotOneBullet), shotInitialTime, shotCooldown);
    }

    private void ShotOneBullet()
    {
        if (enemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
