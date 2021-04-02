using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _xSpeed;
    
    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize target position
        targetPosition = transform.position;
    }

    public void SetTargetPositionX(float xCoord)
    {
        targetPosition = new Vector3(xCoord, 0, 0);
    }

    private void Update()
    {
        // Move player to the target position
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.
                MoveTowards(transform.position, targetPosition, _xSpeed * Time.deltaTime);
        }
    }
}
