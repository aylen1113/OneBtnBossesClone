using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 4f;

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
}