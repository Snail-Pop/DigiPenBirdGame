using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWhileColliding : MonoBehaviour
{

    public int damageAmount = 1;
    public bool destroyOnCollide = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthScript health = collision.gameObject.GetComponent<HealthScript>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
        if (destroyOnCollide)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthScript health = collision.gameObject.GetComponent<HealthScript>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
        if (destroyOnCollide)
        {
            Destroy(gameObject);
        }
    }

}
