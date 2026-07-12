using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 4f;

    private float timer;

    private Collider2D obstacleCollider;
    private PooledObject pooled;

    private void Awake()
    {
        obstacleCollider = GetComponent<Collider2D>();
        pooled = GetComponent<PooledObject>();
    }

    private void OnEnable()
    {
        timer = lifeTime;

        obstacleCollider.enabled = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            obstacleCollider.enabled = false;

            pooled.ReturnToPool();
        }
    }
}