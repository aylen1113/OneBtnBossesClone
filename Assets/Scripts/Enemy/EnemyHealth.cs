using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && canTakeDamage)
        {
            TakeDamage();
            collision.GetComponent<PooledObject>().ReturnToPool();
        }
    }
    protected override void HealthIsZero()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
        GameManager.Instance.Win();
    }
}