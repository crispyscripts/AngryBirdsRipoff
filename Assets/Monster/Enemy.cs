using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Die();
            return;
        }

        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if ((collision.contacts[0].normal.y != 0 || collision.contacts[0].normal.x != 0) && (collision.contacts[0].relativeVelocity.x > 5 || collision.contacts[0].relativeVelocity.y > 1))
        {
            Die();
            return;
        }
    }

    private void Die()
    {
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
