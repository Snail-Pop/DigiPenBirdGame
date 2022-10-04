/*
Name: Tayvian R. Eberle
Date: 10/3/2022
Desc: Works with at least health and DamageOnCollide, can be added to work with other scripts
    Add to objects which you want to have extra effects when they die.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathEffects : MonoBehaviour
{
    [Tooltip("list of functions to run if this object dies and has something that invokes")]
    public UnityEvent deathEvent = new();
    [Tooltip("Add a prefab here if you want this object to drop it on death(Leave empty if not but has other death events)")]
    public GameObject createOnDeath;

    void Start()
    {
        //Add OnDeath function to the death event
        deathEvent.AddListener(OnDeath);
    }

    void OnDeath()
    {
        if (createOnDeath != null)
        {
            Instantiate(createOnDeath, transform.position, Quaternion.identity);
        }
    }
}
