using System.Collections;
using UnityEngine;

// Contains info about player health
// And takes control about damage
[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [Header("Health and damage")]
    [SerializeField] private int _health;
    [SerializeField] private float _minDamageTime;

    [Header("Animation")]
    [SerializeField] private Animation _damageAnimation;
    private bool canTakeDamage = true;

    private void Start()
    {
        // Giving player immortality for the first seconds of game
        StartCoroutine(WaitForNextDamage(_minDamageTime));
    }

    #region Damage
    public void TryTakeDamage(int damage)
    {
        if (damage <= 0)
        {
            damage = 0;
            Debug.LogError("Damage <= 0!");
        }

        if (!canTakeDamage)
        {
            return;
        }

        _health -= damage;
        _damageAnimation.Play();
        Debug.Log($"Got damaged by {damage} \n" +
                  $"Health = {_health}");

        if (_health <= 0)
        {
            Debug.Log("You're lose!");
        }

        StartCoroutine(WaitForNextDamage(_minDamageTime));
    }

    // Give immortality for a while
    private IEnumerator WaitForNextDamage(float timeInSeconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timeInSeconds);
        canTakeDamage = true;
    }
    #endregion
}
