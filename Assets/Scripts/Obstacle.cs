using UnityEngine;

// Report collisions (by the trigger) with player
// And call damage function
[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            // Try apply damage to player
            player.TryTakeDamage(damage);
        }
    }
}
