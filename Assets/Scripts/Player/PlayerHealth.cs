using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : Health
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") && canTakeDamage)
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
    protected override void HealthIsZero()
    {
        Debug.Log("player dead");
        Time.timeScale = 0;
        manager.activatePanel(manager.gameOverPanel);
    }
}