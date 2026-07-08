using UnityEngine;

public class BossConeAttack : MonoBehaviour
{
    public GameObject conePrefab;
    public float circleRadius = 10f;

    public void SpawnCone()
    {
        float randomAngle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * circleRadius;
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Instantiate(conePrefab, spawnPosition, rotation);
    }
}
