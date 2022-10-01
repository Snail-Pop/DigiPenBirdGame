/*
Name: Tayvian Reed Eberle
Date: 9/30/2022
Desc: Damages other collider on collision event
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{


    public int damageAmount = 1;
    public bool destroyOnCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthScript health = collision.gameObject.GetComponent<HealthScript>();
        if(health != null)
        {
            health.TakeDamage(damageAmount);
        }
        if (destroyOnCollide)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthScript health = collision.GetComponent<HealthScript>();
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
