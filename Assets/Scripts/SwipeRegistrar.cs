using System.Collections.Generic;
using UnityEngine;

public class SwipeRegistrar : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;

    private Transform _currentPlayerPosition;
    [SerializeField] private List<Transform> _playerPositions = new List<Transform>(3);

    private void Start()
    {
        _currentPlayerPosition = _playerPositions[1];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            MovePlayer(-1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            MovePlayer(1);
        }
    }

    private void MovePlayer(int xDirection)
    {
        var newIndex = _playerPositions.IndexOf(_currentPlayerPosition) + xDirection;
        if (newIndex >= _playerPositions.Count || newIndex < 0)
        {
            return;
        }

        _player.SetTargetPosition(_playerPositions[newIndex].position);
        _currentPlayerPosition = _playerPositions[newIndex];
    }
}
