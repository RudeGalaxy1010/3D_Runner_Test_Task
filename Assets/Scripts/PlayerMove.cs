using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _xSpeed;
    public float XSpeedMultiplier = 1;
    
    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize target position
        targetPosition = transform.position;
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
        StartCoroutine(ReturnWhenTargetPositionReached(previousPosition));
    }

    private IEnumerator ReturnWhenTargetPositionReached(Vector3 positionToReturn)
    {
        yield return new WaitUntil(()=> targetPosition == transform.position);
        SetTargetPosition(positionToReturn);
    }

    private void Update()
    {
        // Move player to the target position
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.
                MoveTowards(transform.position, targetPosition, _xSpeed * XSpeedMultiplier * Time.deltaTime);
        }
    }
}
