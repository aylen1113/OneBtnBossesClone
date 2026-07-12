using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool pool;

    public void ReturnToPool()
    {
        pool.ReturnObject(gameObject);
    }
}