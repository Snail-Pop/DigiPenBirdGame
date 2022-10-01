/*
Name: Tayvian Reed Eberle
Date: 09/30/2022
Desc: Handles health values on attached objects
 */


using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public bool DestroyAt0 = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {

            if (DestroyAt0)
            {
                DeathEvent(true);
            }
            else
            {
                DeathEvent(false);
            }
        }
    }
    public void GainHealth(int health)
    {

        currentHealth += health;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void DeathEvent(bool shouldDestroy)
    {
        Destroy(gameObject);
    }

}
