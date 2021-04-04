using System.Collections.Generic;
using UnityEngine;

// Contains info about obstacle holders
// And spawn obstacles by the random in holders' positions
public class TrackSegment : MonoBehaviour
{
    public List<Transform> ObstacleHolders = new List<Transform>();
    public List<GameObject> ObstaclePrefabs = new List<GameObject>();

    private void Start()
    {
        // Spawn obstacles in positions randomly
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
        var randomObstaclePrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Count)];
        var newObstacle = Instantiate(randomObstaclePrefab, position, Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        return newObstacle;
    }
}
