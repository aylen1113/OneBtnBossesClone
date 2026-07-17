using System.Collections;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] protected ObstacleFactory factory;
    [SerializeField] protected float attackInterval = 3f;

    public float AttackInterval => attackInterval;

    public abstract IEnumerator ExecuteAttack();
}