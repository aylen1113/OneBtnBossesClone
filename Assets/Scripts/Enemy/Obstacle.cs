using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]

public class Obstacle : MonoBehaviour
{

    public float lifeTime = 4f;

    private float timer;
    private PooledObject pooled;

    public SpriteRenderer spriteRenderer;
    public Collider2D obstacleCollider;

    private void Awake()
    {
        pooled = GetComponent<PooledObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        timer = lifeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (pooled != null)
            {
                pooled.ReturnToPool();
            }
            else
            {
                Debug.LogError("No se encontró el componente PooledObject en " + gameObject.name);
            }
        }
    }
    public IEnumerator Warning(float duration)
    {
        obstacleCollider.enabled = false;

        spriteRenderer.color = new Color(1f, 0f, 0f, 0.4f);

        yield return new WaitForSeconds(duration);

        spriteRenderer.color = Color.white;

        obstacleCollider.enabled = true;
    }
}
