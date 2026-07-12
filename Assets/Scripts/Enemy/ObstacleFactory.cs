using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    public ObjectPool obstaclePool;

    public GameObject CreateObstacle(ObstacleType type, Vector3 position)
    {
        GameObject obstacle = obstaclePool.GetObject();

        obstacle.transform.position = position;
        obstacle.transform.rotation = Quaternion.identity;

        return obstacle;
    }
}