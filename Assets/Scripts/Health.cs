using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Health : MonoBehaviour
{
    //[SerializeField] protected string Bullet;
    [SerializeField] protected int health;
    public bool canTakeDamage = true;


    protected void Start()
    {

        canTakeDamage = true;
    }


    protected void TakeDamage()
    {
        health--;
        Debug.Log("lost a live");

        if (health == 0)
        {
            HealthIsZero();

        }
    }


    protected abstract void HealthIsZero();


 
}