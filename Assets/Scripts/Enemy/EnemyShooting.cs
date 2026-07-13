using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public float speed = 8f;
    public float lifeTime = 4f;

    Vector2 direction;

    float timer;

    PooledObject pooled;

    void Awake()
    {
        pooled = GetComponent<PooledObject>();
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void OnEnable()
    {
        timer = lifeTime;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            pooled.ReturnToPool();
        }
    }
}