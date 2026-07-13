using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    public ObjectPool obstaclePool;
    public ObjectPool conePool;
    public ObjectPool projectilePool;

    public GameObject CreateObstacle(ObstacleType type, Vector3 position)
    {
        return CreateObstacle(type, position, Quaternion.identity);
    }

    public GameObject CreateObstacle(ObstacleType type, Vector3 position, Quaternion rotation)
    {
        GameObject obstacle = null;

        switch (type)
        {
            case ObstacleType.Diamond:
                obstacle = obstaclePool.GetObject();
                break;

            case ObstacleType.Cone:
                obstacle = conePool.GetObject();
                break;

            case ObstacleType.Projectile:
                obstacle = projectilePool.GetObject();
                break;
        }

        obstacle.transform.position = position;
        obstacle.transform.rotation = rotation;

        return obstacle;
    }
}