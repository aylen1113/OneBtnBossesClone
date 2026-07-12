using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float lifeTime = 5f;

    private float timer;

    private PooledObject pooled;

    private void Awake()
    {
        pooled = GetComponent<PooledObject>();
    }

    private void OnEnable()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            pooled.ReturnToPool();
        }
    }
}