using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);

            PooledObject pooled = obj.GetComponent<PooledObject>();

            if (pooled == null)
                pooled = obj.AddComponent<PooledObject>();

            pooled.pool = this;

            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            GameObject obj = Instantiate(prefab, transform);

            PooledObject pooled = obj.GetComponent<PooledObject>();

            if (pooled == null)
                pooled = obj.AddComponent<PooledObject>();

            pooled.pool = this;

            obj.SetActive(false);
            pool.Enqueue(obj);

            Debug.Log("nuevo objeto");
        }

        GameObject objectToUse = pool.Dequeue();
        objectToUse.SetActive(true);

        Debug.Log("objeto obtenido" + pool.Count);

        return objectToUse;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);

        Debug.Log("objeto devuelto" + pool.Count);
    }
}