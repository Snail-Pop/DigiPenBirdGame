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
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public bool DestroyAt0 = true;
    [SerializeField, Tooltip("If this is checked it will spawn a health bar that will follow the object this is assigned to. Not recommended to check this on player script.")]
    bool spawnHealthBar = true;
    [SerializeField, Tooltip("The canvas that the will be used for health bar")]
    Canvas enemyCanvas;
    Canvas curCan;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Awake(){

        if(spawnHealthBar){
            SpawnHealthBar();
        }
        
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
    void SpawnHealthBar(){
        curCan = Instantiate(enemyCanvas, new Vector2 (transform.position.x, transform.position.y - 1), Quaternion.identity);
        Slider healthBarSlider = curCan.GetComponentInChildren<Slider>();
        HealthBar hBScript = healthBarSlider.GetComponentInChildren<HealthBar>();
        hBScript.target = gameObject;
    }
    public void DestroyCanvas(){

        Destroy(curCan.gameObject);

    }
}
