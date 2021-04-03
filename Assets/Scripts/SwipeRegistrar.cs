using System.Collections.Generic;
using UnityEngine;

public class SwipeRegistrar : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;

    private Transform _currentPlayerPosition;
    [SerializeField] private List<Transform> _playerPositions = new List<Transform>(3);

    private void Start()
    {
        var middlePositionIndex = Mathf.FloorToInt(_playerPositions.Count / 2);
        _currentPlayerPosition = _playerPositions[middlePositionIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(1);
        }
    }

    private void MovePlayer(int xDirection)
    {
        var newIndex = _playerPositions.IndexOf(_currentPlayerPosition) + xDirection;

        // If position is behind the left or right wall
        if (newIndex == 0 || newIndex == _playerPositions.Count - 1)
        {
            _player.SetTargetPositionWithReturn(_playerPositions[newIndex].position);
            return;
        }

        // If position is between left and right wall
        _player.SetTargetPosition(_playerPositions[newIndex].position);
        _currentPlayerPosition = _playerPositions[newIndex];
    }
}
