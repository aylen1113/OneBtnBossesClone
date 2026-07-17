using System.Collections;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    [SerializeField] private float initialDelay = 3f;
    [SerializeField] private float timeBetweenAttacks = 4f;

    private AttackBase[] attacks;
    private int lastAttack = -1;

    private void Awake()
    {
        attacks = GetComponents<AttackBase>();
    }

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            int randomAttack;

            do
            {
                randomAttack = Random.Range(0, attacks.Length);
            }
            while (attacks.Length > 1 && randomAttack == lastAttack);

            lastAttack = randomAttack;

            yield return StartCoroutine(attacks[randomAttack].ExecuteAttack());

            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }
}