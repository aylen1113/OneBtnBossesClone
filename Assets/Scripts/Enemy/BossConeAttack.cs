using UnityEngine;

public class BossConeAttack : MonoBehaviour
{
    public ObstacleFactory factory;

    public float attackInterval = 4f;
    public float circleRadius = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackInterval)
        {
            SpawnCone();

            timer = 0;
        }
    }

    void SpawnCone()
    {
        float angle = Random.Range(0f, 360f);

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        Vector2 spawnPosition = direction * circleRadius;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, -direction);

        factory.CreateObstacle(ObstacleType.Cone, spawnPosition, rotation);
    }
}