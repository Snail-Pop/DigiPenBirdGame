using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponDataContainer : ScriptableObject
{

    public int[] fireModes;
    public float shotDelay;
    public GameObject weaponPrefab;
    public GameObject projectile;
    public float damage;
    public int prioritization;
    public float muzzleVelocity;
    public AudioClip shootSound;
    public GameObject muzzleFlashPrefab;

}
