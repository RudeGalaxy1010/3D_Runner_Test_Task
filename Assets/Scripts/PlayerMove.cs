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
