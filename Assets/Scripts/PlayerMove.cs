using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make the player move between positions
// Also controls player's speed
[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    public float XSpeedMultiplier = 1;
    [SerializeField] private float _startXSpeed = 25;

    [Header("Player components")]
    [SerializeField] private List<Transform> _playerPositions = new List<Transform>(3);
    private Transform _currentPlayerPosition;

    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize target position
        targetPosition = transform.position;
        
        // Set a middle position to the player
        var middlePositionIndex = Mathf.FloorToInt(_playerPositions.Count / 2);
        _currentPlayerPosition = _playerPositions[middlePositionIndex];
    }

    private void Update()
    {
        // Move player to the target position
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.
                MoveTowards(transform.position, targetPosition, _startXSpeed * XSpeedMultiplier * Time.deltaTime);
        }
    }

    public void SetSpeedMultiplier(float value)
    {
        XSpeedMultiplier = value;
    }

    public void SetTargetPosition(Vector3 position)
    {
        // If trying to move player not only by X coord
        if (position.y != transform.position.y || position.z != transform.position.z)
        {
            position = new Vector3(position.x, 0, 0);
        }

        targetPosition = position;
    }

    public void SetTargetPositionWithReturn(Vector3 position)
    {
        // Set next position
        var previousPosition = transform.position;
        SetTargetPosition(position);

        // Wait till reach the position and return to previous
        StartCoroutine(ReturnAfterPositionReached(previousPosition));
    }

    public void MovePlayerInXDirection(int xDirection)
    {
        var newIndex = _playerPositions.IndexOf(_currentPlayerPosition) + xDirection;

        // If position is behind the left or right wall
        if (newIndex == 0 || newIndex == _playerPositions.Count - 1)
        {
            SetTargetPositionWithReturn(_playerPositions[newIndex].position);
            return;
        }

        // If position is between left and right wall
        SetTargetPosition(_playerPositions[newIndex].position);
        _currentPlayerPosition = _playerPositions[newIndex];
    }

    private IEnumerator ReturnAfterPositionReached(Vector3 positionToReturn)
    {
        yield return new WaitUntil(()=> targetPosition == transform.position);
        SetTargetPosition(positionToReturn);
    }
}
