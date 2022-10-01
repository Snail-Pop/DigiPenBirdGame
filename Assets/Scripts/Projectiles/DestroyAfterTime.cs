/*
Name: Tayvian Reed Eberle
Date: 9/30/2022
Desc: Script for default projectile behaviour
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    
    public float deathTime;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, deathTime);
    }

}
