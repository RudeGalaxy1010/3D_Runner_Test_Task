using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [Header("Health and damage")]
    [SerializeField] private int _health;
    [SerializeField] private float _minDamageTime;

    private bool canTakeDamage = true;
    private Animation _damageAnimation;

    private void Start()
    {
        _damageAnimation = GetComponent<Animation>();
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

    private IEnumerator WaitForNextDamage(float timeInSeconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(timeInSeconds);
        canTakeDamage = true;
    }
    #endregion
}
