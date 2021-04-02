using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public Transform SafePositionHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            // Try apply damage to player
            player.TryTakeDamage(damage);

            // Teleport player in safe position
            other.GetComponent<PlayerMove>().SetPosition(SafePositionHolder.position);
        }
    }
}
