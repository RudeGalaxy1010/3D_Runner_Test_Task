using System.Collections.Generic;
using UnityEngine;

// Makes the segments move/spawn/destroy
// Also controls segments speed
public class Track : MonoBehaviour
{
    [Header("Speed")]
    public float StartSpeed = 10;
    public float SpeedMultiplier = 1;

    [Header("Segments")]
    [SerializeField] private GameObject _segmentPrefab;
    [SerializeField] private int _segmentsCount = 3;

    private List<GameObject> _segments = new List<GameObject>(3);

    private void Start()
    {
        // Initialize segments, fill the list from the tail
        var halfSegmentsCount = Mathf.FloorToInt(_segmentsCount / 2);
        for (int i = halfSegmentsCount; i >= -halfSegmentsCount; i--)
        {
            var segmentLength = _segmentPrefab.transform.localScale.z;
            var newSegmentPosition = transform.position + Vector3.forward * segmentLength * i;
            var newSegment = SpawnNewSegment(newSegmentPosition);
            _segments.Add(newSegment);
        }
    }

    // The simplest solution (no so good at efficiency)
    private void Update()
    {
        // Move segments
        foreach (var segment in _segments)
        {
            segment.transform.position += Vector3.back * StartSpeed * SpeedMultiplier * Time.deltaTime;
        }

        // Check if segment need to be destroyed
        var cameraZPos = Camera.main.transform.position.z;
        var segmentZPos = _segments[_segments.Count - 1].transform.position.z;
        var maxDistance = _segments[_segments.Count - 1].transform.localScale.z / 2;
        if (cameraZPos - segmentZPos > maxDistance)
        {
            // Destroy segment
            var segmentToDestroy = _segments[_segments.Count - 1];
            _segments.Remove(segmentToDestroy);
            Destroy(segmentToDestroy);

            // Spawn new segment
            var segmentLength = _segmentPrefab.transform.localScale.z;
            var newSegmentPosition = _segments[0].transform.position + Vector3.forward * segmentLength;
            var newSegment = SpawnNewSegment(newSegmentPosition);
            _segments.Insert(0, newSegment);
        }
    }

    public void SetSpeedMultiplier(float value)
    {
        SpeedMultiplier = value;
    }

    private GameObject SpawnNewSegment(Vector3 segmentPosition)
    {
        var newSegment = Instantiate(_segmentPrefab, segmentPosition, Quaternion.identity, transform);
        return newSegment;
    }
}
