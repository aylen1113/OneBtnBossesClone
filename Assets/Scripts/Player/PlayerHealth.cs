using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private PlayerPowerup playerPowerup;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") && canTakeDamage)
        {
            TakeDamage();
            collision.GetComponent<PooledObject>().ReturnToPool();

            if (playerPowerup.IsPowerUpActive)
                return;
        }
    }
    protected override void HealthIsZero()
    {
        Debug.Log("player dead");
        Time.timeScale = 0;
        GameManager.Instance.activatePanel(GameManager.Instance.gameOverPanel);
    }
}