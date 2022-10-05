/*
 * Name: Tayvian R Eberle
 * Date: 10/4/2022
 * Desc: Like damage on collide script however, this runs every frame the colliders are touching
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWhileColliding : MonoBehaviour
{

    public int damageAmount = 1;

    public void DamageOther(Collision2D otherCollision, Collider2D otherCollider)
    {
        if(otherCollision != null)
        {
            if (otherCollision.gameObject.GetComponent<HealthScript>() != null)
            {
                HealthScript otherHScript = otherCollision.gameObject.GetComponent<HealthScript>();
                otherHScript.TakeDamage(damageAmount);
            }
        }

        if (otherCollider != null)
        {
            if (otherCollider.gameObject.GetComponent<HealthScript>() != null)
            {
                HealthScript otherHScript = otherCollider.gameObject.GetComponent<HealthScript>();
                otherHScript.TakeDamage(damageAmount);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
