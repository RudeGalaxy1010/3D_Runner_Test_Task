using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    public List<Transform> ObstacleHolders = new List<Transform>();
    public List<GameObject> ObstaclePrefabs = new List<GameObject>();

    private void Start()
    {
        foreach (var obstacleHolder in ObstacleHolders)
        {
            if (Random.value > 0.5f)
            {
                SpawnObstacle(obstacleHolder.position);
            }
        }
    }

    private GameObject SpawnObstacle(Vector3 position)
    {
        Debug.Log("Spawn Obstacle");
        var randomObstaclePrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Count)];
        var newObstacle = Instantiate(randomObstaclePrefab, position, Quaternion.identity, transform);
        return newObstacle;
    }
}
