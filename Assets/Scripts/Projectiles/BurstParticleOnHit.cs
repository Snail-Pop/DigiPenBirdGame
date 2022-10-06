/*
 * Name: Tayvian R Eberle
 * Date: 10/5/2022
 * Desc: Spawns a collision particle effect upon attached gameobject being destroyed.
 */

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstParticleOnHit : MonoBehaviour
{

    public GameObject ParticleGameObject;
    public void OnDestroy()
    {
        try
        {
            SpawnParticles(ParticleGameObject);
        }
        catch
        {
            Instantiate(gameObject);
        }
    }

    public void SpawnParticles(GameObject particleObj)
    {

        Instantiate(ParticleGameObject, transform.position, Quaternion.identity);
    }
}
